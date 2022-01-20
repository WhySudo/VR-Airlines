using System.Collections.Generic;
using Gameplay.Aircraft;
using UnityEngine;

namespace Gameplay.Settings
{
    [CreateAssetMenu(fileName = "gameSettings", menuName = "Settings/Game Settings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [Header("Main Settings")]
        [SerializeField] public List<AircraftEntity> aircraftList;
        
    }
}