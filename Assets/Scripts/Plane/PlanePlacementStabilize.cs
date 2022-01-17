using System;
using UnityEngine;
using Valve.VR;

namespace Plane
{
    public class PlanePlacementStabilize : MonoBehaviour
    {
        [SerializeField] private float moveIntensity;
        [SerializeField] private float rotateIntensity;
        [SerializeField] private SteamVR_Action_Vector2 joystick;
        private void Update()
        {
            UpdatePlacement();
        }

        private void UpdatePlacement()
        {
            transform.localPosition += new Vector3(joystick.GetAxis(SteamVR_Input_Sources.RightHand).x * moveIntensity * Time.deltaTime, 0,
                joystick.GetAxis(SteamVR_Input_Sources.RightHand).y * moveIntensity * Time.deltaTime);

            if (Mathf.Abs(joystick.GetAxis(SteamVR_Input_Sources.LeftHand).x) > 0.15)
            {
                transform.localRotation *=
                    Quaternion.AngleAxis(
                        joystick.GetAxis(SteamVR_Input_Sources.LeftHand).x * rotateIntensity * Time.deltaTime,
                        Vector3.up);
            }
        }
    }
}