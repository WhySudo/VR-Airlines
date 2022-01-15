using System;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;
using Valve.VR;

namespace UserInput
{
    public class VRRigTracking : MonoBehaviour
    {
        [Header("Links")] [SerializeField] private VRInputConfig vrConfig;
        [SerializeField] private InputChannel inputChannel;
        [SerializeField] private TrackableJoystickRig leftRig;
        [SerializeField] private TrackableJoystickRig rightRig;

        [Header("Debug")]
        [SerializeField] private bool lockInput = false;

        private void Update()
        {
            DetectInput();
        }

        private void DetectInput()
        {
            CheckLockInputs();
            if (lockInput) return;
            Debug.Log(leftRig.AlignedDelta);
            Debug.Log(rightRig.AlignedDelta);
            inputChannel.UpdatePitch(GetPitchAngle());
            inputChannel.UpdateBank(GetBankAngle());
            inputChannel.UpdateYaw(GetYawAngle());
            inputChannel.ChangeSpeed(GetAcceleration());
        }

        private void CheckLockInputs()
        {
            if (Input.GetAxis(vrConfig.rightButtonAxisName) > 0f)
            {
                lockInput = true;
            }
            else if (Input.GetAxis(vrConfig.leftTriggerAxisName) > 0f)
            {
                lockInput = false;
            }
        }

        private float GetPitchAngle()
        {
            return -rightRig.AlignedDelta.z;
        }

        private float GetBankAngle()
        {
            return -rightRig.AlignedDelta.x;
        }

        private float GetYawAngle()
        {
            return -leftRig.AlignedDelta.x;
        }

        private float GetAcceleration()
        {
            var returnValue = Input.GetAxis(vrConfig.rightTriggerAxisName) -
                              Input.GetAxis(vrConfig.leftTriggerAxisName);
            return returnValue;
        }
    }
}