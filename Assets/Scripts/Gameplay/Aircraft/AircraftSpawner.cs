using System;
using Gameplay.Channels;
using Gameplay.Etc;
using Gameplay.Player;
using Gameplay.Settings;
using Gameplay.UserInput;
using UnityEngine;

namespace Gameplay.Aircraft
{
    public class AircraftSpawner : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private AircraftEventsChannel aircraftEventsChannel;
        [SerializeField] private InputChannel inputChannel;
        
        [Header("Debug")] 
        [SerializeField] private AircraftEntity spawnedAircraft;
        [SerializeField] private Vector3 lastPosition = Vector3.zero;
        [SerializeField] private Quaternion lastRotation = Quaternion.identity;
        [SerializeField] private int spawnedAircraftId = 0;


        public void SpawnRandomAircraft()
        {
            
        }
        public void SpawnNextAircraft()
        {
            Debug.Log("Respawn");
            spawnedAircraftId = (spawnedAircraftId + 1) % gameSettings.aircraftList.Count;
            SpawnSelectedAircraft();
        }
        public void SpawnAircraft(AircraftEntity planePrefab)
        {
            if (spawnedAircraft != null)
            {
                DestroyAircraft();
            }
            spawnedAircraft = Instantiate(planePrefab);
            spawnedAircraft.transform.position = lastPosition;
            spawnedAircraft.transform.rotation = lastRotation;
            aircraftEventsChannel.AircraftSpawn(spawnedAircraft);
        }
        
        private void Start()
        {
            SpawnSelectedAircraft();
        }

        private void OnEnable()
        {
            inputChannel.ChangePlaneRequestEvent.AddListener(OnPlaneChangeRequested);
        }

        private void OnPlaneChangeRequested(ChangePlaneRequestArgs args)
        {
            switch (args.changeType)
            {
                case ChangePlaneType.Next:
                    SpawnNextAircraft();
                    break;
                    
                case ChangePlaneType.Random:
                    SpawnRandomAircraft();
                    break;
            }
        }
        private void OnDisable()
        {
            inputChannel.ChangePlaneRequestEvent.RemoveListener(OnPlaneChangeRequested);
        }
        

        private void SpawnSelectedAircraft()
        {
            SpawnAircraft(gameSettings.aircraftList[spawnedAircraftId]);
        }
        private void DestroyAircraft()
        {
            if (spawnedAircraft == null) return;
            aircraftEventsChannel.BeforeDestroyAircraft(spawnedAircraft);
            lastPosition = spawnedAircraft.transform.position;
            lastRotation = spawnedAircraft.transform.rotation;
            Destroy(spawnedAircraft.gameObject);
            spawnedAircraft = null;
        }
    }
}