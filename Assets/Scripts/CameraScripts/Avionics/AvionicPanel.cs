using System;
using System.Collections.Generic;
using Plane;
using UnityEngine;

namespace CameraScripts.Avionics
{
    public class AvionicPanel : MonoBehaviour
    {
        [SerializeField] private PlaneMovement plane;
        [SerializeField] private List<AvionicElement> elements;

        private void Start()
        {
            SetupElements(plane);
        }

        private void SetupElements(PlaneMovement setPlane)
        {
            foreach (var element in elements)
            {
                element.ChangePlaneReference(setPlane);
            }
        }
    }
}