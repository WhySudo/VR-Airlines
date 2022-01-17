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

        [Header("Debug")] [SerializeField] private bool lockLeft = true;
        [SerializeField] private bool lockRight = true;

        [SerializeField] private SteamVR_Action_Single inputTriggerAction;
        [SerializeField] private SteamVR_Action_Vector2 joystick;


        
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
            inputChannel.AutoAlign = Mathf.Abs(joystick.GetAxis(SteamVR_Input_Sources.LeftHand).y) > vrConfig.detectAutoAlign;
            inputChannel.UpdatePitch(lockRight ? 0 : GetPitchAngle());
            inputChannel.UpdateBank(lockRight ? 0 : GetBankAngle());
            inputChannel.UpdateYaw(lockLeft ? 0 : GetYawAngle());
            inputChannel.ChangeSpeed(lockLeft ? 0 : GetAcceleration());
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
            var pitch = Mathf.Pow(Mathf.Pow(-rightRig.AlignedDelta.z, 2) + Mathf.Pow(rightRig.AlignedDelta.y, 2), .5f) *
                        (-rightRig.AlignedDelta.z > 0 ? 1 : -1f);
            pitch = Mathf.Clamp(pitch, -1, 1);
            
            return pitch;
        }

        private float GetBankAngle()
        {
            return rightRig.DeltaXRotation;
        }

        private float GetYawAngle()
        {
            return -leftRig.AlignedDelta.x;
        }

        private float GetAcceleration()
        {
            return -leftRig.AlignedDelta.z;
        }
    }
}