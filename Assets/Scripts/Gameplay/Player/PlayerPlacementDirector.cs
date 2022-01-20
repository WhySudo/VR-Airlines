using Gameplay.Aircraft.Events;
using Gameplay.Channels;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerPlacementDirector : MonoBehaviour
    {
        [SerializeField] private AircraftEventsChannel aircraftEventsChannel;
        [SerializeField] private PlayerPresentation player;
        [SerializeField] private Transform safeContainer;
        private void OnEnable()
        {
            aircraftEventsChannel.AircraftBeforeDestroyingEvent.AddListener(BeforeAircraftDestroy);
            aircraftEventsChannel.AircraftSpawnedEvent.AddListener(OnAircraftSpawn);
        }
        private void OnAircraftSpawn(AircraftSpawnedArgs arg0)
        {
            arg0.spawnedAircraft.PlayerPlacement.PutPlayer(player);
        }
        private void BeforeAircraftDestroy(AircraftBeforeDestroyingArgs arg0)
        {
            player.transform.parent = safeContainer;
        }
        private void OnDisable()
        {
            aircraftEventsChannel.AircraftSpawnedEvent.RemoveListener(OnAircraftSpawn);
            aircraftEventsChannel.AircraftBeforeDestroyingEvent.RemoveListener(BeforeAircraftDestroy);
        }
    }
}