using System;
using UnityEngine;
using UserInput;
using UserInput.Events;

namespace Plane
{
    public class PlaneMovement : MonoBehaviour
    {
        [Header("Links")] 
        [SerializeField] private InputChannel inputChannel;
        [SerializeField] private MovementSettings movementSettings;

        private float speed;
        public float Speed => speed;

        public float Pitch => Vector3.SignedAngle(transform.forward,
            Vector3.ProjectOnPlane(transform.forward, movementSettings.comparePlane), -transform.right);
        public float Bank => Vector3.SignedAngle(transform.right, Vector3.ProjectOnPlane(transform.right, movementSettings.comparePlane), -transform.forward);
        
        public float Yaw 
        {
            get
            {
                var check = Vector3.ProjectOnPlane(transform.forward, Vector3.up);
                var angle = Vector3.SignedAngle(Vector3.forward, check, Vector3.up);
                return angle;
            }
        }
        
        private void Start()
        {
            speed = movementSettings.baseSpeed;
        }

        private void OnEnable()
        {
            inputChannel.ChangeSpeedRequestEvent.AddListener(OnSpeedChangeRequest);
        }

        private void OnSpeedChangeRequest(ChangeSpeedRequestArgs arg0)
        {
            speed = Mathf.Max( speed + arg0.deltaSpeed * movementSettings.speedChange * Time.deltaTime, 0);
        }

        private void Update()
        {
            ProcessMovement();
        }

        private void ProcessMovement()
        {
            if (speed <= 0) return;
            
            BankRotation();
            PitchRotation();
            YawRotation();
            MoveForward();
        }

        private void MoveForward()
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }

        private void PitchRotation()
        {
            var setPitch = 0f;
            if (inputChannel.AutoAlign)
            {
                var pitch = Pitch;
                if (pitch > 0)
                {
                    setPitch = -1;
                }
                else if (pitch < 0)
                {
                    setPitch = 1;
                }
            }
            else
            {
                setPitch = inputChannel.Pitch;
            }
            var deltaAngle = setPitch * movementSettings.pitchMaxSpeed * Time.deltaTime;
            var rotation = Quaternion.AngleAxis(deltaAngle, movementSettings.pitchAxis);
            transform.rotation *= rotation;
        }
        private void BankRotation()
        {
            var setBank = 0f;
            if (inputChannel.AutoAlign)
            {
                var bank = Bank;
                if (bank > 0)
                {
                    setBank = -1;
                }
                else if (bank < 0)
                {
                    setBank = 1;
                }
            }
            else
            {
                setBank = inputChannel.Bank;
            }
            var deltaAngle = setBank* movementSettings.bankMaxSpeed * Time.deltaTime;
            var rotation = Quaternion.AngleAxis(deltaAngle, movementSettings.bankAxis);
            transform.rotation *= rotation;
        }
        private void YawRotation()
        {
            var deltaAngle = inputChannel.Yaw * movementSettings.yawMaxSpeed * Time.deltaTime;
            var rotation = Quaternion.AngleAxis(deltaAngle, movementSettings.yawAxis);
            transform.rotation *= rotation;
        }
        private void OnDisable()
        {
            inputChannel.ChangeSpeedRequestEvent.RemoveListener(OnSpeedChangeRequest);
        }
    }
}