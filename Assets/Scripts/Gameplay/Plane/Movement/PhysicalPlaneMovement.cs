using UnityEngine;

namespace Gameplay.Plane.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PhysicalPlaneMovement : PlaneMovement
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected override void MovePlane()
        {
            //TODO: физика))
        }
    }
}