using System.Collections.Generic;
using Gameplay.Aircraft.Movement;
using Gameplay.Aircraft.Visualisation.Parts;
using Gameplay.Channels;
using Gameplay.Settings;
using UnityEngine;

namespace Gameplay.Aircraft.Visualisation
{
    public class AircraftEmpennage : AircraftVisualisation
    {
        
        [Header("Ailerons")]
        [SerializeField] private List<RotatableAircraftPart> leftAilerons;
        [SerializeField] private List<RotatableAircraftPart> rightAilerons;
        
        [Header("Elevators")] 
        [SerializeField] private List<RotatableAircraftPart> elevators;
        [SerializeField] private List<RotatableAircraftPart> trimmers;
        [SerializeField] private List<AircraftRotorPart> propellers;
        private AircraftConfiguration AircraftConfiguration => aircraft.AircraftConfiguration;

        private void Update()
        {
            UpdateAilerons();
            UpdateElevators();
            UpdateTrimmers();
            MoveRotor();
        }


        private void UpdateElevators()
        {
            foreach (var elevator in elevators)
            {
                elevator.SetRotation(inputChannel.Pitch);
            }
        }

        private void UpdateAilerons()
        {
            foreach (var leftAileron in leftAilerons)
            {
                leftAileron.SetRotation(inputChannel.Bank);
            }
            foreach (var rightAileron in rightAilerons)
            {
                rightAileron.SetRotation(-inputChannel.Bank);
            }
        }

        private void UpdateTrimmers()
        {
            foreach (var trimmer in trimmers)
            {
                trimmer.SetRotation(inputChannel.Yaw);
            }
        }

        private void MoveRotor()
        {
            foreach (var propeller in propellers)
            {
                propeller.RotatePart(aircraft.EngineSpeed);
            }
        }
    }
}