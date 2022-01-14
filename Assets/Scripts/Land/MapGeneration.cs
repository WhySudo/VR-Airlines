using System;
using System.Collections.Generic;
using System.Linq;
using Plane;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Land
{
    public class MapGeneration : MonoBehaviour
    {
        [Header("Links")] 
        [SerializeField] private Transform playerPoint;
        [SerializeField] private Transform tilesParent;
        [SerializeField] private List<GameObject> tilesPrefab;
        

        [Header("Settings")] 
        [SerializeField] private MovementSettings movementSettings;
        [SerializeField] private int sidePrefabCount;
        [SerializeField] private int frontPrefabCount;
        [SerializeField] private float deltaX;
        [SerializeField] private float deltaZ;

        private Dictionary<Vector2Int, GameObject> spawnedTiles = new Dictionary<Vector2Int, GameObject>();
        private Vector2Int _prevPoint = new Vector2Int(1000, 1000);
        private void Update()
        {
            CheckGenerate();
        }

        private void CheckGenerate()
        {
            var rawPos = Vector3.ProjectOnPlane(playerPoint.position, movementSettings.comparePlane);
            var point = GetInternalPoint(rawPos);
            if (point != _prevPoint)
            {
                _prevPoint = point;
                Generate(point);
            }
        }
        private void Generate(Vector2Int point)
        {
            
            SpawnPoints(GetPointsToSpawn(point));
        }

        private Vector2Int GetInternalPoint(Vector3 coord)
        {
            
            return new Vector2Int(Mathf.CeilToInt(coord.x / deltaX), Mathf.CeilToInt(coord.z / deltaZ));
        }

        private Vector3 GetWorldPoint(Vector2Int coord)
        {
            return new Vector3(coord.x * deltaX, 0, coord.y * deltaZ);
        }
        private void SpawnPoints(Vector2Int[] newData)
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
                    SpawnObject(newPos);
                }
            }
            foreach (var destroy in alreadyKeys)
            {
                Destroy(spawnedTiles[destroy]);
                spawnedTiles.Remove(destroy);
            }
        }

        private void SpawnObject(Vector2Int pos)
        {
            var wPos = GetWorldPoint(pos);
            var prefIdx = Random.Range(0, tilesPrefab.Count);
            var obj = Instantiate(tilesPrefab[prefIdx], tilesParent);
            obj.transform.position = wPos;
            spawnedTiles[pos] = obj;
        }
        private Vector2Int[] GetPointsToSpawn(Vector2Int point)
        {
            var list = new List<Vector2Int>();
            for (int x = point.x-sidePrefabCount; x <= point.x+sidePrefabCount; x++)
            {
                for (int z = point.y-frontPrefabCount; z <= point.y+frontPrefabCount; z++)
                {
                    list.Add(new Vector2Int(x, z));
                }
            }
            return list.ToArray();
        }
     }
}
