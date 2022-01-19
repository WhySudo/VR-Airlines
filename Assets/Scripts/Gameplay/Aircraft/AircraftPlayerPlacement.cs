using UnityEngine;
using Valve.VR;

namespace Gameplay.Aircraft
{
    public class AircraftPlayerPlacement : MonoBehaviour
    {
        [SerializeField] private float moveIntensity;
        [SerializeField] private float rotateIntensity;
        [SerializeField] private SteamVR_Action_Vector2 joystick;

        public void PutPlayer(Transform playerEntity)
        {
            playerEntity.parent = transform;
            playerEntity.localPosition = Vector3.zero;
            playerEntity.localRotation = Quaternion.Euler(Vector3.zero);
        }
        private void Update()
        {
            UpdatePlacementFromInput();
        }

        private void UpdatePlacementFromInput()
        {
            transform.localPosition += new Vector3(
                joystick.GetAxis(SteamVR_Input_Sources.RightHand).x * moveIntensity * Time.deltaTime, 0,
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