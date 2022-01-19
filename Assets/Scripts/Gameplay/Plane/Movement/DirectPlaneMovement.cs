using UnityEngine;

namespace Gameplay.Plane.Movement
{
    public class DirectPlaneMovement : PlaneMovement
    {
        protected override void MovePlane()
        {
            var setPosition = transform.position + transform.forward * (speed * Time.deltaTime);
            if (setPosition.y < movementSettings.minY)
            {
                setPosition = new Vector3(setPosition.x, movementSettings.minY, setPosition.z);
            }
            transform.position = setPosition;
        }
    }
}