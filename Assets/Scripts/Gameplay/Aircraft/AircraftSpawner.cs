using System;
using Gameplay.Channels;
using Gameplay.Settings;
using UnityEngine;

namespace Gameplay.Aircraft
{
    public class AircraftSpawner : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private Transform playerEntity;
        [SerializeField] private AircraftEventsChannel aircraftEventsChannel;
        
        [Header("Debug")] 
        [SerializeField] private AircraftEntity spawnedAircraft;
        [SerializeField] private Vector3 lastPosition = Vector3.zero;
        [SerializeField] private Quaternion lastRotation = Quaternion.identity;
        [SerializeField] private int spawnedAircraftId = 0;


        private void Start()
        {
            SpawnSelectedAircraft();
        }

        public void SpawnNextAircraft()
        {
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
            spawnedAircraft.PlayerPlacement.PutPlayer(playerEntity);
        }

        private void SpawnSelectedAircraft()
        {
            SpawnAircraft(gameSettings.aircraftList[spawnedAircraftId]);
        }
        private void DestroyAircraft()
        {
            if (spawnedAircraft == null) return;
            playerEntity.parent = transform;
            lastPosition = spawnedAircraft.transform.position;
            lastRotation = spawnedAircraft.transform.rotation;
            
            Destroy(spawnedAircraft.gameObject);
            spawnedAircraft = null;
        }
    }
}