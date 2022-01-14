using System;
using UnityEngine;

namespace CameraScripts
{
    public class LookAtTransform : MonoBehaviour
    {
        [SerializeField] private Transform followTransform;

        private void Update()
        {
            transform.LookAt(followTransform);
        }
    }
}
