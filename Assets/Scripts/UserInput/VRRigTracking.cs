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


        [Header("Settings")] 
        [SerializeField] private float leftBaseZ;
        [SerializeField] private float leftBaseX;
        [SerializeField] private float leftBaseRotZ;
        [SerializeField] private float rightBaseZ;
        private void Update()
        {
            DetectInput();
        }

        private void DetectInput()
        {
            inputChannel.UpdatePitch(GetPitchAngle());
            inputChannel.UpdateBank(GetBankAngle());
            inputChannel.UpdateYaw(GetYawAngle());
            inputChannel.ChangeSpeed(GetAcceleration());
        }

        private float GetPitchAngle()
        {
            return Mathf.Clamp( leftRig.position.z - leftBaseZ, -1, 1);
        }
        private float GetBankAngle()
        {
            return Mathf.Clamp( leftRig.rotation.eulerAngles.z - leftBaseRotZ, -1, 1);
        }
        private float GetYawAngle()
        {
            return Mathf.Clamp( leftRig.position.x - leftBaseX, -1, 1);
        }
        private float GetAcceleration()
        {
            return Mathf.Clamp(rightRig.position.z - rightBaseZ, -1, 1);
        }
    }
}