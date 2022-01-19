using System.Collections.Generic;
using Gameplay.Plane;
using Gameplay.Plane.Movement;
using UnityEngine;

namespace Gameplay.Avionics
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