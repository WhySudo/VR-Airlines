using Gameplay.Player;
using UnityEngine.Events;

namespace Gameplay.Etc
{
    public class PlacementPlayerPutEvent : UnityEvent<PlacementPlayerPutArgs>
    {
    }

    public class PlacementPlayerPutArgs
    {
        public PlayerPresentation reference;

        public PlacementPlayerPutArgs(PlayerPresentation reference)
        {
            this.reference = reference;
        }
    }
}