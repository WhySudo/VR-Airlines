using System;
using Gameplay.Aircraft.Visualisation.Parts;
using UnityEngine;

namespace Gameplay.Aircraft.Visualisation
{
    public class AircraftPedals : AircraftVisualisation
    {
        [SerializeField] private PushableAircraftPart leftPedal;
        [SerializeField] private PushableAircraftPart rightPedal;

        private void Update()
        {
            UpdatePedalsPos();
        }
        private void UpdatePedalsPos()
        {
            var leftPedalValue = 0f;
            var rightPedalValue = 0f;
            if (inputChannel.Yaw > 0)
            {
                leftPedalValue = (inputChannel.Yaw + 1f) / 2f;
            }
            else if (inputChannel.Yaw < 0)
            {
                rightPedalValue = (inputChannel.Yaw - 1f) / -2f;
            }
            if (inputChannel.SpeedChange < 0)
            {
                var oldLeft = leftPedalValue;
                var oldRight = rightPedalValue;
                leftPedalValue = 1 - (oldRight / 2f);
                rightPedalValue = 1 - (oldLeft / 2f);
            }
            leftPedal.SetPushing(leftPedalValue);
            rightPedal.SetPushing(rightPedalValue);
        }
    }
}