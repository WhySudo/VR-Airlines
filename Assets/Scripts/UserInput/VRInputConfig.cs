using System;
using UnityEngine;

namespace UserInput
{
    [CreateAssetMenu(fileName = "VRInputConfig", menuName = "Settings/VRInput", order = 0)]
    public class VRInputConfig : ScriptableObject
    {
        [SerializeField] public Vector3 defaultFront;
        [SerializeField] public float maxAngle;
        [SerializeField] public float rigsMaxDelta;
        [SerializeField] public float cutoutDelta;
        [SerializeField] public float cutoutDeltaAngle = 0.4f;
        [SerializeField] public string leftTriggerAxisName;
        [SerializeField] public string rightTriggerAxisName;
        [SerializeField] public string leftButtonAxisName;
        [SerializeField] public string rightButtonAxisName;

        private void OnValidate()
        {
            cutoutDelta = Mathf.Clamp01(cutoutDelta);
        }
    }
}