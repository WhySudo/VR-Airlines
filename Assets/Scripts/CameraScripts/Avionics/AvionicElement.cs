using Plane;
using UnityEngine;

namespace CameraScripts.Avionics
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