using Gameplay.Aircraft;
using Gameplay.Aircraft.Events;
using UnityEngine;

namespace Gameplay.Channels
{
    [CreateAssetMenu(fileName = "aircraftEventsChannel", menuName = "Channels/Aircraft Events Channel", order = 0)]
    public class AircraftEventsChannel : ScriptableObject
    {
        public readonly AircraftBeforeDestroyingEvent AircraftBeforeDestroyingEvent =
            new AircraftBeforeDestroyingEvent();
        public readonly AircraftSpawnedEvent AircraftSpawnedEvent = new AircraftSpawnedEvent();

        public void BeforeDestroyAircraft(AircraftEntity entity)
        {
            AircraftBeforeDestroyingEvent.Invoke(new AircraftBeforeDestroyingArgs(entity));
        }
    }
}