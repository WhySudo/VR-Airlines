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
            txt.Append($"\nSpeed: {aircraftMovement.EngineSpeed:F1}\n\n");
            txt.Append($"Pitch: {aircraftMovement.Pitch:F1}\n");
            txt.Append($"Bank: {aircraftMovement.Bank:F1}\n");
            txt.Append($"Yaw: {aircraftMovement.Yaw:F1}\n");
            text.text = txt.ToString();
        }
    }
}