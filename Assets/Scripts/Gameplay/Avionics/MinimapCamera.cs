using UnityEngine;

namespace Gameplay.Avionics
{
    public class MinimapCamera : AvionicElement
    {
        [SerializeField] private Vector3 offset;
        
        private void Update()
        {
            FollowPlane();
        }

        private void FollowPlane()
        {
            var check = Vector3.ProjectOnPlane(AircraftMovement.transform.forward, Vector3.up);
            var angle = Vector3.SignedAngle(Vector3.forward, check, Vector3.up);
            transform.rotation = Quaternion.Euler(0, angle, 0);
            transform.position = AircraftMovement.transform.position + offset;
        }
    }
}