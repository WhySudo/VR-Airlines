using UnityEngine;

namespace UserInput
{
    [CreateAssetMenu(fileName = "VRInputConfig", menuName = "Settings/VRInput", order = 0)]
    public class VRInputConfig : ScriptableObject
    {
        [SerializeField] public Vector3 defaultFront;
        [SerializeField] public float rigsMaxDelta;
        [SerializeField] public string leftTriggerAxisName;
        [SerializeField] public string rightTriggerAxisName;
        [SerializeField] public string leftButtonAxisName;
        [SerializeField] public string rightButtonAxisName;
    }
}