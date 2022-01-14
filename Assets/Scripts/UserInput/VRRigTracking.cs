using System;
using UnityEngine;

namespace UserInput
{
    public class VRRigTracking : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private InputChannel inputChannel;
        [SerializeField] private Transform leftRig;
        [SerializeField] private Transform rightRig;

        [Header("Camera")]
        [SerializeField] private Transform cameraObject;
        [SerializeField] private Transform cameraParent;
        [Header("Settings")] 
        [SerializeField] private float leftBaseZ;
        [SerializeField] private float leftBaseX;
        [SerializeField] private float leftBaseRotZ;
        [SerializeField] private float rightBaseZ;


        private Vector3 rightOrigin;
        private Vector3 leftOrigin;

        private void Start()
        {
            rightOrigin = rightRig.position;
            leftOrigin = leftRig.position;
        }

        private void Update()
        {
            DetectInput();
        }

        private void DetectInput()
        {
            var accel = GetAcceleration();
            Debug.Log(accel);
            inputChannel.UpdatePitch(GetPitchAngle());
            inputChannel.UpdateBank(GetBankAngle());
            inputChannel.UpdateYaw(GetYawAngle());
            inputChannel.ChangeSpeed(GetAcceleration());
        }

        private float GetPitchAngle()
        {
            return Mathf.Clamp( (leftRig.position - leftOrigin).z - leftBaseZ, -1, 1);
        }
        private float GetBankAngle()
        {
            return Mathf.Clamp( leftRig.rotation.eulerAngles.z - leftBaseRotZ, -1, 1);
        }
        private float GetYawAngle()
        {
            return Mathf.Clamp( (leftRig.position - leftOrigin).x - leftBaseX, -1, 1);
        }
        private float GetAcceleration()
        {
            return Mathf.Clamp((rightRig.position - rightOrigin).z - rightBaseZ, -1, 1);
        }
    }
}