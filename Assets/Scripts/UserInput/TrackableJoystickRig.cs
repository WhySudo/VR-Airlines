using System;
using UnityEngine;

namespace UserInput
{
    public class TrackableJoystickRig : MonoBehaviour
    {
        [Header("Settings")] [SerializeField] private Transform container;
        [SerializeField] private VRInputConfig vrConfig;

        [Header("Debug")] [SerializeField] private Vector3 delta;
        [SerializeField] private Vector3 pivotPoint;
        public Vector3 PivotPoint => pivotPoint;


        private float NormalizeCutout(float rawValue)
        {
            if (Mathf.Abs(rawValue) < vrConfig.cutoutDelta) return 0;
            else
            {
                return (Mathf.Abs(rawValue) - vrConfig.cutoutDeltaAngle) / (1 - vrConfig.cutoutDeltaAngle) * rawValue /
                       Mathf.Abs(rawValue);
            }
        }

        public float DeltaFromUpRotation
        {
            get
            {
                var rawAngle = Mathf.Clamp(Vector3.SignedAngle(container.up, transform.up, transform.forward),
                    -vrConfig.maxAngle, vrConfig.maxAngle) / vrConfig.maxAngle;
                return NormalizeCutout(rawAngle);
            }
        }


        public Vector3 AlignedDelta =>
            Quaternion.FromToRotation(Vector3.ProjectOnPlane(transform.forward, container.up), container.forward
            ) * UnalignedDelta;

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

        private void CheckPivotUpdate()
        {
            var delta = RawDelta;
            if (delta.magnitude > MaxDelta)
            {
                pivotPoint = transform.localPosition - delta.normalized * MaxDelta;
            }
        }
    }
}