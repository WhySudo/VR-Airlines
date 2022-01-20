using UnityEngine;

namespace Gameplay.Aircraft.Visualisation.Parts
{
    public class PushableAircraftPart : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private float maxMovement;
        [SerializeField] private float smoothTime = 0.1f;
        [SerializeField] private Vector3 localDirection;
        private Vector3 _targetPos;
        private Vector3 _speed = Vector3.zero;

        public void SetPushing(float value)
        {
            _targetPos = value*maxMovement*localDirection;
        }

        private void Update()
        {
            var curTransform = transform;
            curTransform.localPosition = Vector3.SmoothDamp(curTransform.localPosition, _targetPos, ref _speed, smoothTime);
        }
    }
}