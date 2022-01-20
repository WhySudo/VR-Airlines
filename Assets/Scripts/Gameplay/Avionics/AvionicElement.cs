using Gameplay.Aircraft;
using Gameplay.Aircraft.Movement;
using Gameplay.Settings;
using UnityEngine;

namespace Gameplay.Avionics
{
    public abstract class AvionicElement : MonoBehaviour
    {
        [SerializeField] protected AircraftEntity aircraft;
        protected AircraftMovement AircraftMovement => aircraft.AircraftMovement;
        protected AircraftConfiguration AircraftConfiguration => AircraftMovement.AircraftConfiguration;

        public void ChangePlane(AircraftEntity newPlane)
        {
            aircraft = newPlane;
        }
    }
}