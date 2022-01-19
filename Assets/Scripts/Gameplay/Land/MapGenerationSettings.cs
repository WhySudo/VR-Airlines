using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Land
{
    [CreateAssetMenu(fileName = "mapGenerationSettings", menuName = "Settings/MapGenerationSettings", order = 0)]
    public class MapGenerationSettings : ScriptableObject
    {
        [Header("TilesPrefabSpawner")] 
        [SerializeField] public List<GameObject> tilesElements;
        [SerializeField] public GameObject startPrefab;
        [SerializeField] public int sidePrefabCount;
        [SerializeField] public int frontPrefabCount;
        [SerializeField] public float tileDeltaX;
        [SerializeField] public float tileDeltaZ;

        [Header("tileElements")] 
        [SerializeField] public Vector2Int tileElementsCount;
        [SerializeField] public Vector2Int tileElementsDelta;
        [SerializeField] public float tileElementsDeltaX;
        [SerializeField] public float tileElementsDeltaZ;
    }
}