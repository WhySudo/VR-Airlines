using Gameplay.Aircraft.Events;
using Gameplay.Channels;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerPresentation : MonoBehaviour
    {
        [SerializeField] private Camera playerCamera;
        public Camera PlayerCamera => playerCamera;
        
    }
}