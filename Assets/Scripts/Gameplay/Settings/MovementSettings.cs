using UnityEngine;

namespace Gameplay.Settings
{
    [CreateAssetMenu(fileName = "movementSettings", menuName = "Settings/Movement", order = 0)]
    public class MovementSettings : ScriptableObject
    {
        [Header("Movement Axis")] 
        [SerializeField] public Vector3 pitchAxis = Vector3.right;
        [SerializeField] public Vector3 bankAxis = Vector3.forward;
        [SerializeField] public Vector3 yawAxis = Vector3.up;
        [SerializeField] public Vector3 rotorAxis;
        
        [Header("Max Rotation Speeds (per second)")]
        [SerializeField] public float pitchMaxSpeed; 
        [SerializeField] public float bankMaxSpeed;
        [SerializeField] public float yawMaxSpeed;
        
        [Header("Speed")] 
        [SerializeField] public float baseSpeed;
        [SerializeField] public float speedChange;
        [SerializeField] public float baseRotorSpeed;
        
        [Header("ETC")]
        [SerializeField] public Vector3 comparePlane = Vector3.up;
        [SerializeField] public float minY = 0;
    }
}