using Gameplay.Settings;
using UnityEngine;

namespace Gameplay.Aircraft.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PhysicalAircraftMovement : AircraftMovement
    {
        [SerializeField] private PhysicalMovementSettings physicalMovementSettings;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected override void PitchRotation()
        {
            
        }

        protected override void BankRotation()
        {
            
        }

        protected override void YawRotation()
        {
            
        }

        protected override void MovePlane()
        {
            var upForce = UpForce();    
        }

        private Vector3 UpForce()
        {
            var attackAngle = Pitch;
            var speed = _rigidbody.velocity;
            var floatSpeed = speed.magnitude;
            var square = physicalMovementSettings.wingSquare;
            var density = physicalMovementSettings.airDensity;
            var mass = _rigidbody.mass;
            var power = engineSpeed * physicalMovementSettings.enginePowerMultiplier;
            return Vector3.back;
        }
    }
}