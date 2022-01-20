using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Avionics
{
    public class BaseDataPanel : AvionicElement
    {
        [SerializeField] private Text text;

        private void Update()
        {
            UpdateText();
        }

        private void UpdateText()
        {
            var txt = new StringBuilder();
            txt.Append($"\nSpeed: {AircraftMovement.EngineSpeed:F1}\n\n");
            txt.Append($"Pitch: {AircraftMovement.Pitch:F1}\n");
            txt.Append($"Bank: {AircraftMovement.Bank:F1}\n");
            txt.Append($"Yaw: {AircraftMovement.Yaw:F1}\n");
            text.text = txt.ToString();
        }
    }
}