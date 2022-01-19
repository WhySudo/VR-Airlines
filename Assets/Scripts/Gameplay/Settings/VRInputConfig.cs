using UnityEngine;

namespace Gameplay.Settings
{
    [CreateAssetMenu(fileName = "VRInputConfig", menuName = "Settings/VRInput", order = 0)]
    public class VRInputConfig : ScriptableObject
    {
        [SerializeField] public Vector3 defaultFront;
        [SerializeField] public float maxAngle;
        [SerializeField] public float rigsMaxDelta;
        [SerializeField] public float cutoutDelta;
        [SerializeField] public float cutoutDeltaAngle = 0.4f;
        [Header("delta angles")]
        [SerializeField] public float xDeltaAngle;
        [SerializeField] public float zDeltaAngle;
        [SerializeField] public float detectAutoAlign;

        private void OnValidate()
        {
            cutoutDelta = Mathf.Clamp01(cutoutDelta);
        }
    }
}