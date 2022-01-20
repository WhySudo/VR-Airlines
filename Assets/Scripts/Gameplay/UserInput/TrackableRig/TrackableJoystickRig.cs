using System;
using Gameplay.Aircraft.Events;
using Gameplay.Channels;
using Gameplay.Settings;
using UnityEngine;

namespace Gameplay.UserInput.TrackableRig
{
    public class TrackableJoystickRig : MonoBehaviour
    {
        [Header("Settings")] [SerializeField] private Transform container;
        [SerializeField] private VRInputConfig vrConfig;
        [SerializeField] private AircraftEventsChannel aircraftEventsChannel;

        [Header("Debug")] [SerializeField] private Vector3 delta;
        [SerializeField] private Vector3 pivotPoint;
        public Vector3 PivotPoint => pivotPoint;
        private bool inputLocked = true;
        public bool InputLocked => inputLocked;

        private float NormalizeCutout(float rawValue)
        {
            if (Mathf.Abs(rawValue) < vrConfig.cutoutDelta) return 0;
            return (Mathf.Abs(rawValue) - vrConfig.cutoutDeltaAngle) / (1 - vrConfig.cutoutDeltaAngle) * rawValue /
                   Mathf.Abs(rawValue);
        }

        public float DeltaXRotation
        {
            get
            {
                var rawAngle = Mathf.Clamp(
                    vrConfig.xDeltaAngle + Vector3.SignedAngle(container.right, transform.right, container.forward),
                    -vrConfig.maxAngle, vrConfig.maxAngle) / vrConfig.maxAngle;
                return NormalizeCutout(rawAngle);
            }
        }


        public Vector3 AlignedDelta 
        {
            get
            {
                var baseQuaterion = transform.localRotation * Quaternion.Inverse(_storedRotation);
                return Quaternion.FromToRotation(Vector3.ProjectOnPlane(baseQuaterion*transform.forward, container.up), container.forward
                    // Quaternion.FromToRotation(transform.forward, container.forward
                ) * UnalignedDelta;
            }
        }
            

        public Vector3 UnalignedDelta
        {
            get
            {
                var delta = RawDelta / MaxDelta;
                if (delta.magnitude <= vrConfig.cutoutDelta)
                {
                    return Vector3.zero;
                }

                return delta;
            }
        }

        private Vector3 RawDelta
        {
            get { return transform.localPosition - pivotPoint; }
        }

        private float MaxDelta => vrConfig.rigsMaxDelta;

        private Vector3 _storedFront;
        private Quaternion _storedRotation;

        private void Start()
        {
            pivotPoint = transform.localPosition;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(PivotPoint, MaxDelta);
        }

        private void Update()
        {
            delta = UnalignedDelta;
            CheckPivotUpdate();
        }

        public void UnlockInput()
        {
            inputLocked = false;
            _storedFront = transform.forward;
            pivotPoint = transform.localPosition;
            _storedRotation = transform.localRotation;
        }

        public void LockInput()
        {
            inputLocked = true;
        }

        private void CheckPivotUpdate()
        {
            var delta = RawDelta;
            if (delta.magnitude > MaxDelta)
            {
                pivotPoint = transform.localPosition - delta.normalized * MaxDelta;
            }
        }

        private void OnEnable()
        {
            aircraftEventsChannel.AircraftSpawnedEvent.AddListener(OnAircraftSpawn);
        }

        private void OnAircraftSpawn(AircraftSpawnedArgs arg0)
        {
            container = arg0.spawnedAircraft.transform;
        }

        private void OnDisable()
        {
            aircraftEventsChannel.AircraftSpawnedEvent.RemoveListener(OnAircraftSpawn);
        }
    }
}