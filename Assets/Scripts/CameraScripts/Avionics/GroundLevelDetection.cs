using UnityEngine;
using UnityEngine.UI;

namespace CameraScripts.Avionics
{
    public class GroundLevelDetection : AvionicElement
    {
        [SerializeField] public Text displayGround;
        [SerializeField] private float groundLevel;

        private void Update()
        {
            var height = planeMovement.transform.position.y - groundLevel;
            displayGround.text = $"{height:F1} M";
        }
    }
}