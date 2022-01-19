using Gameplay.Plane;
using Gameplay.Plane.Movement;
using UnityEngine;

namespace Gameplay.Avionics
{
    public abstract class AvionicElement : MonoBehaviour
    {
        [SerializeField] protected PlaneMovement planeMovement;
        public void ChangePlaneReference(PlaneMovement newPlane)
        {
            planeMovement = newPlane;
        }
    }
}