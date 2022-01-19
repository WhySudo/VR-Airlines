using System.Collections.Generic;
using Gameplay.Aircraft;
using Gameplay.Aircraft.Movement;
using Gameplay.Channels;
using Gameplay.Settings;
using UnityEngine;

namespace Gameplay.Plane
{
    public class AircraftEmpennageVisualisation : MonoBehaviour
    {
        [Header("Links")] 
        [SerializeField] private InputChannel inputChannel;
        [SerializeField] private AircraftMovement aircraft;
        
        [Header("Ailerons")]
        [SerializeField] private RotatableAircraftPart leftAileron;
        [SerializeField] private RotatableAircraftPart rightAileron;

        [Header("Elevators")] 
        [SerializeField] private List<RotatableAircraftPart> elevators;

        [SerializeField] private RotatableAircraftPart trimmer;
        [SerializeField] private Transform propeller;
        private AircraftConfiguration AircraftConfiguration => aircraft.AircraftConfiguration;

        private void Update()
        {
            UpdateAilerons();
            UpdateElevators();
            UpdateTrimmer();
            MoveRotor();
        }


        private void UpdateElevators()
        {
            foreach (var elevator in elevators)
            {
                elevator.Rotate(inputChannel.Pitch);
            }
        }

        private void UpdateAilerons()
        {
            leftAileron.Rotate(inputChannel.Bank);
            rightAileron.Rotate(-inputChannel.Bank);
        }

        private void UpdateTrimmer()
        {
            trimmer.Rotate(inputChannel.Yaw);
        }

        private void MoveRotor()
        {
            propeller.rotation *= Quaternion.AngleAxis(AircraftConfiguration.baseRotorSpeed * Time.deltaTime,
                AircraftConfiguration.rotorAxis * aircraft.EngineSpeed / AircraftConfiguration.baseSpeed);
        }
    }
}