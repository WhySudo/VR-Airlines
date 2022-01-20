using UnityEngine.Events;

namespace Gameplay.Aircraft.Events
{
    public class AircraftSpawnedEvent : UnityEvent<AircraftSpawnedArgs>
    {
    }

    public class  AircraftSpawnedArgs
    {
        public AircraftEntity spawnedAircraft;

        public AircraftSpawnedArgs(AircraftEntity spawnedAircraft)
        {
            this.spawnedAircraft = spawnedAircraft;
        }
    }
}