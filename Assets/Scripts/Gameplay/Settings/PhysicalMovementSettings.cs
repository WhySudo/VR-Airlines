using UnityEngine;

namespace Gameplay.Settings
{
    [CreateAssetMenu(fileName = "physicalMovement", menuName = "Settings/PhysicalMovement", order = 0)]
    public class PhysicalMovementSettings : ScriptableObject
    {
        [SerializeField] public float wingSquare;
        [SerializeField] public float airDensity;
        [SerializeField] public float enginePowerMultiplier;
        [SerializeField] public AnimationCurve upForce;
    }
}