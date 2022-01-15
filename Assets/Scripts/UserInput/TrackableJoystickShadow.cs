using System;
using UnityEngine;

namespace UserInput
{
    public class TrackableJoystickShadow : MonoBehaviour
    {
        [SerializeField] private TrackableJoystickRig followRig;

        private void Update()
        {
            transform.localPosition = followRig.PivotPoint;
            transform.rotation = followRig.transform.rotation;
        }
    }
}