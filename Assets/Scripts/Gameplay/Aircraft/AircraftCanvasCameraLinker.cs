using System;
using System.Collections.Generic;
using Gameplay.Etc;
using UnityEngine;

namespace Gameplay.Aircraft
{
    public class AircraftCanvasCameraLinker : MonoBehaviour
    {
        [SerializeField] private AircraftPlayerPlacement aircraftPlayerPlacement;
        [SerializeField] private List<Canvas> aircraftCanvas;

        private void OnEnable()
        {
            aircraftPlayerPlacement.PlacementPlayerPutEvent.AddListener(OnPlayerPut);
        }

        private void OnPlayerPut(PlacementPlayerPutArgs args)
        {
            foreach (var canvas in aircraftCanvas)
            {
                canvas.worldCamera = args.reference.PlayerCamera;
            }
        }

        private void OnDisable()
        {
            aircraftPlayerPlacement.PlacementPlayerPutEvent.RemoveListener(OnPlayerPut);
        }
    }
}