using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserInput;

namespace Plane
{
    public class PlaneEmpennageVisualisation : MonoBehaviour
    {
        [Header("Links")] [SerializeField] private InputChannel inputChannel;
        [SerializeField] private MovementSettings movementSettings;
        [SerializeField] private PlaneMovement plane;
        [Header("Ailerons")] [SerializeField] private RotatingPlane leftAileron;
        [SerializeField] private RotatingPlane rightAileron;

        [Header("Elevators")] [Tooltip("Рули высоты")] [SerializeField]
        private List<RotatingPlane> elevators;

        [SerializeField] private RotatingPlane trimmer;
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
                movementSettings.rotorAxis * plane.Speed / movementSettings.baseSpeed);
        }
    }
}