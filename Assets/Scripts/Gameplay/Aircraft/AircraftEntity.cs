using Gameplay.Aircraft.Movement;
using Gameplay.Settings;
using UnityEngine;

namespace Gameplay.Aircraft
{
    public class AircraftEntity : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private AircraftConfiguration configuration;
        [SerializeField] private AircraftPlayerPlacement playerPlacement;
        [SerializeField] private AircraftMovement aircraftMovement;
        public AircraftConfiguration Configuration => configuration;
        public AircraftPlayerPlacement PlayerPlacement => playerPlacement;
        public AircraftMovement AircraftMovement => aircraftMovement;

    }
}