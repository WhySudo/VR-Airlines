using UnityEngine;

namespace Gameplay.Avionics
{
    public class MiniMapCameraRotation : AvionicElement
    {
        private void Update()
        {
            var check = Vector3.ProjectOnPlane(planeMovement.transform.forward, Vector3.up);
            var angle = Vector3.SignedAngle(Vector3.forward, check, Vector3.up);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
}