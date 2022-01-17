using Plane;
using UnityEngine;
using UnityEngine.UI;

namespace CameraScripts.Avionics
{
    public class GroundLevelDetection : AvionicElement
    {
        [SerializeField] public Text displayGround;
        [SerializeField] private MovementSettings movementSettings;

        private void Update()
        {
            var height = planeMovement.transform.position.y - movementSettings.minY;
            displayGround.text = $"{height:F1} M";
        }
    }
}