using System;
using Gameplay.Aircraft.Visualisation.Parts;
using UnityEngine;

namespace Gameplay.Aircraft.Visualisation
{
    public class AircraftSteeringWheel : AircraftVisualisation
    {
        [SerializeField] private PushableAircraftPart steeringWheelPushing;
        [SerializeField] private RotatableAircraftPart steeringWheelRotation;
        private void Update()
        {
            UpdateSteeringWheel();
        }

        private void UpdateSteeringWheel()
        {
            steeringWheelRotation.SetRotation(-inputChannel.Bank);
            steeringWheelPushing.SetPushing(inputChannel.Pitch);
        }
    }
}