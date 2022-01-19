using System;
using Gameplay.Aircraft.Events;
using Gameplay.Channels;
using UnityEngine;

namespace Gameplay.Etc
{
    public class PlayerPlacement : MonoBehaviour
    {
        [SerializeField] private AircraftEventsChannel aircraftEventsChannel;

        private void OnEnable()
        {
            aircraftEventsChannel.AircraftBeforeDestroyingEvent.AddListener(BeforeAircraftDestroy);
        }

        private void BeforeAircraftDestroy(AircraftBeforeDestroyingArgs arg0)
        {
            
        }
        private void OnDisable()
        {
            aircraftEventsChannel.AircraftBeforeDestroyingEvent.RemoveListener(BeforeAircraftDestroy);
        }
    }
}