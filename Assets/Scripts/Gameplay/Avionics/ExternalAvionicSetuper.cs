using System;
using System.Collections.Generic;
using Gameplay.Aircraft;
using Gameplay.Aircraft.Events;
using Gameplay.Channels;
using UnityEngine;

namespace Gameplay.Avionics
{
    public class ExternalAvionicSetuper : MonoBehaviour
    {
        [SerializeField] private AircraftEventsChannel aircraftEventsChannel;
        [SerializeField] private List<AvionicElement> externalAvionic;

        private void OnEnable()
        {
            aircraftEventsChannel.AircraftSpawnedEvent.AddListener(OnAircraftSpawn);
        }

        private void OnAircraftSpawn(AircraftSpawnedArgs args)
        {
            foreach (var avionic in externalAvionic)
            {
                avionic.ChangePlane(args.spawnedAircraft);
            }
        }

        private void OnDisable()
        {
            
            aircraftEventsChannel.AircraftSpawnedEvent.RemoveListener(OnAircraftSpawn);
        }
    }
}