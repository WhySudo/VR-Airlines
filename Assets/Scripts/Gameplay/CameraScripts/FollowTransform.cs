using UnityEngine;

namespace Gameplay.CameraScripts
{
    public class FollowTransform : MonoBehaviour
    {
        [SerializeField] private Transform followTransform;
        [SerializeField] private bool checkOnStart = true;

        private Vector3 _offset;

        private void Start()
        {
            if (checkOnStart)
            {
                _offset = transform.position - followTransform.position;
            }
        }

        private void Update()
        {
            transform.position = followTransform.position + _offset;
        }
    }
}