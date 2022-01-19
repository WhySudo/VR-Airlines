using Gameplay.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Avionics
{
    public class GroundLevelDisplayer : AvionicElement
    {
        [SerializeField] public Text displayGround;

        private void Update()
        {
            var height = aircraftMovement.transform.position.y - AircraftConfiguration.minY;
            displayGround.text = $"{height:F1} M";
        }
    }
}