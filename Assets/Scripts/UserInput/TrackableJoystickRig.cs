﻿using System;
using UnityEngine;

namespace UserInput
{
    public class TrackableJoystickRig : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private Transform container;
        [SerializeField] private VRInputConfig vrConfig;

        [Header("Debug")]
        [SerializeField] private Vector3 delta;
        [SerializeField] private Vector3 pivotPoint;
        public Vector3 PivotPoint => pivotPoint;

        public Vector3 AlignedDelta =>
            Quaternion.FromToRotation(Vector3.ProjectOnPlane(transform.forward, container.up), container.forward
                ) * UnalignedDelta;

        public Vector3 UnalignedDelta => RawDelta / MaxDelta;
        private Vector3 RawDelta => transform.localPosition - pivotPoint;
        
        private float MaxDelta => vrConfig.rigsMaxDelta;
        

        private void Start()
        {
            pivotPoint = transform.localPosition;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(PivotPoint, MaxDelta);
            
        }

        private void Update()
        {
            delta = UnalignedDelta;
            CheckPivotUpdate();
        }

        private void CheckPivotUpdate()
        {
            var delta = RawDelta;
            if (delta.magnitude > MaxDelta)
            {
                pivotPoint = transform.localPosition - delta.normalized * MaxDelta;
            }
        }
    }
}