using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Land
{
    public class GeneratedMapTile : MonoBehaviour
    {
        [SerializeField] private MapGenerationSettings generationSettings;
        [SerializeField] private List<GameObject> mapObjects;
        private void Awake()
        {
            GenerateTile();
        }

        private void GenerateTile()
        {
            for (var x = generationSettings.tileElementsDelta.x;
                x < generationSettings.tileElementsDelta.x + generationSettings.tileElementsCount.x;
                x++)
            {
                for (var z = generationSettings.tileElementsDelta.y;
                    z < generationSettings.tileElementsDelta.y + generationSettings.tileElementsCount.y;
                    z++)
                {
                    var tile = mapObjects[
                        Random.Range(0, mapObjects.Count)];
                    var spawnedTile = Instantiate(tile, transform);
                    spawnedTile.transform.localPosition = GetTilePosition(x, z);
                    spawnedTile.transform.localRotation = Quaternion.Euler(0, 60 * Random.Range(0, 6),0);
                    if (spawnedTile.TryGetComponent<Collider>(out var collider))
                    {
                        collider.enabled = false;
                    }
                }
            }
        }

        private Vector3 GetTilePosition(int x, int y)
        {
            return new Vector3(x * generationSettings.tileElementsDeltaX - (y % 2 != 0?generationSettings
                .tileElementsDeltaX * 0.5f : 0)
               ,0,y*generationSettings.tileElementsDeltaZ);
        }
    }
}