using System.Collections.Generic;
using System.Linq;
using Gameplay.Settings;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Land
{
    public class MapGeneration : MonoBehaviour
    {
        [Header("Links")] 
        [SerializeField] private Transform playerPoint;
        [SerializeField] private Transform tilesParent;
        [SerializeField] private GameObject tilePrefab;
        

        [Header("Settings")] 
        [SerializeField] private MovementSettings movementSettings;
        [SerializeField] private MapGenerationSettings generationSettings;

        private Dictionary<Vector2Int, GameObject> spawnedTiles = new Dictionary<Vector2Int, GameObject>();
        private Vector2Int _prevPoint = new Vector2Int(1000, 1000);
        private void Update()
        {
            CheckForGeneration();
        }

        private void CheckForGeneration()
        {
            var rawPos = Vector3.ProjectOnPlane(playerPoint.position, movementSettings.comparePlane);
            var point = GetInternalPoint(rawPos);
            if (point != _prevPoint)
            {
                _prevPoint = point;
                GenerateMapAtPoint(point);
            }
        }
        private void GenerateMapAtPoint(Vector2Int point)
        {
            SpawnTilesAtPoint(GetPointsToSpawn(point));
        }

        private Vector2Int GetInternalPoint(Vector3 coord)
        {
            return new Vector2Int(Mathf.CeilToInt(coord.x / generationSettings.tileDeltaX), Mathf.CeilToInt(coord.z / generationSettings.tileDeltaZ));
        }

        private Vector3 GetWorldPoint(Vector2Int coord)
        {
            return new Vector3(coord.x * generationSettings.tileDeltaX, 0, coord.y * generationSettings.tileDeltaZ);
        }
        private void SpawnTilesAtPoint(Vector2Int[] newData)
        {
            var alreadyKeys = spawnedTiles.Keys.ToList();
            var newKeys = newData.ToList();
            foreach (var newPos in newKeys)
            {
                if (alreadyKeys.Contains(newPos))
                {
                    alreadyKeys.Remove(newPos);
                }
                else
                {
                    SpawnTileAtPoint(newPos);
                }
            }
            foreach (var destroy in alreadyKeys)
            {
                Destroy(spawnedTiles[destroy]);
                spawnedTiles.Remove(destroy);
            }
        }

        private void SpawnTileAtPoint(Vector2Int pos)
        {
            var wPos = GetWorldPoint(pos);
            GameObject obj;
            if (pos == Vector2Int.zero)
            {
                obj = Instantiate(generationSettings.startPrefab, tilesParent);
            }
            else
            {
                obj = Instantiate(tilePrefab, tilesParent);
            }
            obj.transform.position = wPos;
            spawnedTiles[pos] = obj;
        }
        private Vector2Int[] GetPointsToSpawn(Vector2Int point)
        {
            var list = new List<Vector2Int>();
            for (int x = point.x-generationSettings.sidePrefabCount; x <= point.x+generationSettings.sidePrefabCount; x++)
            {
                for (int z = point.y-generationSettings.frontPrefabCount; z <= point.y+generationSettings.frontPrefabCount; z++)
                {
                    list.Add(new Vector2Int(x, z));
                }
            }
            return list.ToArray();
        }
     }
}
