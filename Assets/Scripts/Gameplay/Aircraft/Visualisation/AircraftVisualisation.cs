using Gameplay.Aircraft.Movement;
using Gameplay.Channels;
using UnityEngine;

namespace Gameplay.Aircraft.Visualisation
{
    public abstract class AircraftVisualisation : MonoBehaviour
    {
        
        [Header("Links")] 
        [SerializeField] protected InputChannel inputChannel;
        [SerializeField] protected AircraftMovement aircraft;
    }
}