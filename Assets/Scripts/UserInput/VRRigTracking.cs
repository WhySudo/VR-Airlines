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

        [Header("Debug")] [SerializeField] private bool lockInput = true;

        private SteamVR_Action_Single inputTriggerAction;
        public bool InputLocked => lockInput;

        private void Update()
        {
            DetectInput();
        }

        private void Awake()
        {
            SteamVR.Initialize();
            inputTriggerAction = SteamVR_Input.GetAction<SteamVR_Action_Single>(vrConfig.joystickAxisName);
            leftRig.LockInput();
            rightRig.LockInput();
        }


        private void DetectInput()
        {
            CheckLockInputs();
            if (lockInput) return;
            inputChannel.UpdatePitch(GetPitchAngle());
            inputChannel.UpdateBank(GetBankAngle());
            inputChannel.UpdateYaw(GetYawAngle());
            inputChannel.ChangeSpeed(GetAcceleration());
        }

        private void CheckLockInputs()
        {
            if (inputTriggerAction.axis > 0f)
            {
                if (lockInput == true)
                {
                    leftRig.UnlockInput();
                    rightRig.UnlockInput();
                }

                lockInput = false;
            }
            else
            {
                if (lockInput == false)
                {
                    leftRig.LockInput();
                    rightRig.LockInput();
                }

                lockInput = true;
            }
        }

        private float GetPitchAngle()
        {
            return -rightRig.DeltaZRotation;
        }

        private float GetBankAngle()
        {
            return rightRig.DeltaXRotation;
        }

        private float GetYawAngle()
        {
            return -rightRig.AlignedDelta.x;
        }

        private float GetAcceleration()
        {
            return -leftRig.AlignedDelta.z;
        }
    }
}