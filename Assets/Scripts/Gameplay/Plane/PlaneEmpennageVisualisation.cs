using System.Collections.Generic;
using Gameplay.Channels;
using Gameplay.Plane.Movement;
using Gameplay.Settings;
using UnityEngine;

namespace Gameplay.Plane
{
    public class PlaneEmpennageVisualisation : MonoBehaviour
    {
        [Header("Links")] 
        [SerializeField] private InputChannel inputChannel;
        [SerializeField] private MovementSettings movementSettings;
        [SerializeField] private PlaneMovement plane;
        
        [Header("Ailerons")]
        [SerializeField] private RotatablePlanePart leftAileron;
        [SerializeField] private RotatablePlanePart rightAileron;

        [Header("Elevators")] 
        [SerializeField] private List<RotatablePlanePart> elevators;

        [SerializeField] private RotatablePlanePart trimmer;
        [SerializeField] private Transform propeller;

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
            propeller.rotation *= Quaternion.AngleAxis(movementSettings.baseRotorSpeed * Time.deltaTime,
                movementSettings.rotorAxis * plane.EngineSpeed / movementSettings.baseSpeed);
        }
    }
}