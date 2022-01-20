using UnityEngine;

namespace Gameplay.Aircraft.Movement
{
    public class DirectAircraftMovement : AircraftMovement
    {
        protected override void MovePlane()
        {
            var setPosition = transform.position + transform.forward * (engineSpeed * Time.deltaTime);
            if (setPosition.y < gameSettings.minY)
            {
                setPosition = new Vector3(setPosition.x, gameSettings.minY, setPosition.z);
            }
            transform.position = setPosition;
        }
    }
}