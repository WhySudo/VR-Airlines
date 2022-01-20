using Gameplay.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Avionics
{
    public class GroundLevelDisplayer : AvionicElement
    {
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] public Text displayGround;

        private void Update()
        {
            var height = AircraftMovement.transform.position.y - gameSettings.minY;
            displayGround.text = $"{height:F1} M";
        }
    }
}