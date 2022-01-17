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
        [SerializeField] private bool lockLeft = true;
        [SerializeField] private bool lockRight = true;

        [SerializeField] private SteamVR_Action_Single inputTriggerAction;
    

        private void Update()
        {
            DetectInput();
        }

        private void Awake()
        {
            SteamVR.Initialize();
            leftRig.LockInput();
            rightRig.LockInput();
        }


        private void DetectInput()
        {
            CheckLockInputs();
            inputChannel.UpdatePitch(lockRight?0:GetPitchAngle());
            inputChannel.UpdateBank(lockRight?0:GetBankAngle());
            inputChannel.UpdateYaw(lockLeft?0:GetYawAngle());
            inputChannel.ChangeSpeed(lockLeft?0:GetAcceleration());
        }

        private void CheckLockInputs()
        {
            if (inputTriggerAction.GetAxis(SteamVR_Input_Sources.LeftHand) > 0f)
            {
                if (lockLeft)
                {
                    leftRig.UnlockInput();
                }

                lockLeft = false;
            }
            else
            {
                if (lockLeft == false)
                {
                    leftRig.LockInput();
                }

                lockLeft = true;
            }
            if (inputTriggerAction.GetAxis(SteamVR_Input_Sources.RightHand) > 0f)
            {
                if (lockRight)
                {
                    rightRig.UnlockInput();
                }

                lockRight = false;
            }
            else
            {
                if (lockRight == false)
                {
                    rightRig.LockInput();
                }

                lockRight = true;
            }
        }

        private float GetPitchAngle()
        {
            return -rightRig.AlignedDelta.z;
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