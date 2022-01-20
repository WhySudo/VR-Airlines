using Gameplay.Channels;
using Gameplay.Settings;
using Gameplay.UserInput.TrackableRig;
using UnityEngine;
using Valve.VR;

namespace Gameplay.UserInput
{
    public class VRRigTracking : MonoBehaviour
    {
        [Header("Links")] 
        [SerializeField] private VRInputConfig vrConfig;
        [SerializeField] private InputChannel inputChannel;
        [SerializeField] private TrackableJoystickRig leftRig;
        [SerializeField] private TrackableJoystickRig rightRig;
        [SerializeField] private SteamVR_Action_Single inputTriggerAction;
        [SerializeField] private SteamVR_Action_Vector2 joystick;
        [SerializeField] private SteamVR_Action_Boolean planeSwitchButton;

        [Header("Debug")] 
        [SerializeField] private bool lockLeft = true;
        [SerializeField] private bool lockRight = true;



        private bool _planePressed = false;
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

            CheckPlaneSwitch();
            CheckLockInputs();
            
            inputChannel.AutoAlign = Mathf.Abs(joystick.GetAxis(SteamVR_Input_Sources.LeftHand).y) > vrConfig.detectAutoAlign;
            inputChannel.UpdatePitch(lockRight ? 0 : GetPitchAngle());
            inputChannel.UpdateBank(lockRight ? 0 : GetBankAngle());
            inputChannel.UpdateYaw(lockLeft ? 0 : GetYawAngle());
            inputChannel.ChangeSpeed(lockLeft ? 0 : GetAcceleration());
        }

        private void CheckPlaneSwitch()
        {
            if (planeSwitchButton.state != _planePressed)
            {
                _planePressed = planeSwitchButton.state;
                if (_planePressed)
                {
                    inputChannel.RequestPlaneChange();
                }
            }
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
            return -leftRig.AlignedDelta.x;
        }

        private float GetAcceleration()
        {
            return leftRig.AlignedDelta.z;
        }
    }
}