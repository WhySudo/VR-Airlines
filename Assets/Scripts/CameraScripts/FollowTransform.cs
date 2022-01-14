using System;
using UnityEngine;

namespace CameraScripts
{
    public class FollowTransform : MonoBehaviour
    {
        [SerializeField] private Transform followTransform;
        [SerializeField] private bool checkOnStart = true;

        private Vector3 offset;

        private void Start()
        {
            if (checkOnStart)
            {
                offset = transform.position - followTransform.position;
            }
        }

        private void Update()
        {
            transform.position = followTransform.position + offset;
        }
    }
}