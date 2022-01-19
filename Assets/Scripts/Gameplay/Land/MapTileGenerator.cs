using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Land
{
    public class MapTileGenerator : MonoBehaviour
    {
        [SerializeField] private MapGenerationSettings generationSettings;

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
                    var tile = generationSettings.tilesElements[
                        Random.Range(0, generationSettings.tilesElements.Count)];
                    var spawnedTile = Instantiate(tile, transform);
                    spawnedTile.transform.localPosition = GetTilePosition(x, z);
                    spawnedTile.transform.localRotation = Quaternion.Euler(0, 60 * Random.Range(0, 6),0);
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