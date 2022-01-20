using UnityEngine;

namespace Gameplay.Aircraft.Visualisation.Parts
{
    public class AircraftRotorPart : MonoBehaviour
    {
        [SerializeField] private float baseRotorSpeed;
        [SerializeField] private Vector3 rotorAxis;

        public void RotatePart(float speed)
        {
            transform.rotation *= Quaternion.AngleAxis(baseRotorSpeed * Time.deltaTime * speed,
                rotorAxis);
        }
    }
}