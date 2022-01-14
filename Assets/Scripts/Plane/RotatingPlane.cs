﻿using System;
using UnityEngine;

namespace Plane
{
    public class RotatingPlane : MonoBehaviour
    {
        [Header("Settings")] [SerializeField] private float maxAngle;
        [SerializeField] private Vector3 rotatingAxis;
        [SerializeField] private float smoothTime = 0.1f;
        private float _targetAngle;
        private float _currentAngle = 0;
        private float _rotSpeed = 0;

        public void Rotate(float angle)
        {
            _targetAngle = angle*maxAngle;
        }

        private void Update()
        {
            var prevAn = _currentAngle;
            _currentAngle = Mathf.SmoothDampAngle(_currentAngle, _targetAngle, ref _rotSpeed, smoothTime);
            transform.Rotate(rotatingAxis, _currentAngle-prevAn);
        }
    }
}