using Gameplay.Aircraft.Movement;
using Gameplay.Plane;
using Gameplay.Settings;
using UnityEngine;

namespace Gameplay.Avionics
{
    public abstract class AvionicElement : MonoBehaviour
    {
        [SerializeField] protected AircraftMovement aircraftMovement;
        protected AircraftConfiguration AircraftConfiguration => aircraftMovement.AircraftConfiguration;
        
    }
}