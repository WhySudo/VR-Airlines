using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace CameraScripts.Avionics
{
    public class BaseData : AvionicElement
    {
        [SerializeField] private Text text;

        private void Update()
        {
            UpdateText();
        }

        private void UpdateText()
        {
            var txt = new StringBuilder();
            txt.Append($"\nSpeed: {planeMovement.Speed:F1}\n\n");
            txt.Append($"Pitch: {planeMovement.Pitch:F1}\n");
            txt.Append($"Bank: {planeMovement.Bank:F1}\n");
            txt.Append($"Yaw: {planeMovement.Yaw:F1}\n");
            text.text = txt.ToString();
        }
    }
}