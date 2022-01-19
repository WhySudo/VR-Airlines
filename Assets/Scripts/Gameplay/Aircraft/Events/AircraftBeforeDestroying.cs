using UnityEngine.Events;

namespace Gameplay.Aircraft.Events
{
    public class AircraftBeforeDestroyingEvent : UnityEvent<AircraftBeforeDestroyingArgs>
    {
    }

    public class AircraftBeforeDestroyingArgs
    {
        public AircraftEntity entity;

        public AircraftBeforeDestroyingArgs(AircraftEntity entity)
        {
            this.entity = entity;
        }
    }
}