using Gameplay.Channels;
using Gameplay.Settings;
using UnityEngine;

namespace Gameplay.Aircraft.Movement
{
    public abstract class AircraftMovement : MonoBehaviour
    {
        [Header("Links")] 
        [SerializeField] protected InputChannel inputChannel;
        [SerializeField] protected AircraftEntity aircraftEntity;
        [SerializeField] protected GameSettings gameSettings;
        public AircraftConfiguration AircraftConfiguration => aircraftEntity.Configuration; 

        protected float engineSpeed;
        public float EngineSpeed => engineSpeed;

        public float Pitch => Vector3.SignedAngle(transform.forward,
            Vector3.ProjectOnPlane(transform.forward, AircraftConfiguration.comparePlane), -transform.right);
        public float Bank => Vector3.SignedAngle(transform.right, Vector3.ProjectOnPlane(transform.right, AircraftConfiguration.comparePlane), -transform.forward);
        
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
            engineSpeed = 0;
        }


       

        private void Update()
        {
            ProcessMovement();
        }

        private void ProcessMovement()
        {
            DetectSpeedChange();
            if (engineSpeed <= 0) return;
            BankRotation();
            PitchRotation();
            YawRotation();
            MovePlane();
            
        }

        private void DetectSpeedChange()
        {
            engineSpeed = Mathf.Clamp( engineSpeed + inputChannel.SpeedChange * AircraftConfiguration.speedChange * Time.deltaTime, 0, AircraftConfiguration.maxSpeed);
        }

        protected abstract void MovePlane();

        protected virtual void PitchRotation()
        {
            var setPitch = 0f;
            if (inputChannel.AutoAlign)
            {
                var pitch = Pitch;
                if (pitch > 0)
                {
                    setPitch = Mathf.Min(1f, pitch);
                }
                else if (pitch < 0)
                {
                    setPitch = Mathf.Max(-1f, pitch);
                }
            }
            else
            {
                setPitch = inputChannel.Pitch;
            }
            var deltaAngle = setPitch * AircraftConfiguration.pitchMaxSpeed * Time.deltaTime;
            var rotation = Quaternion.AngleAxis(deltaAngle, AircraftConfiguration.pitchAxis);
            transform.rotation *= rotation;
        }
        protected virtual void BankRotation()
        {
            var setBank = 0f;
            if (inputChannel.AutoAlign)
            {
                var bank = Bank;
                if (bank > 0)
                {
                    setBank = Mathf.Max(-1f, -bank);
                }
                else if (bank < 0)
                {
                    setBank = Mathf.Min(1f, -bank);
                }
            }
            else
            {
                setBank = inputChannel.Bank;
            }
            var deltaAngle = setBank* AircraftConfiguration.bankMaxSpeed * Time.deltaTime;
            var rotation = Quaternion.AngleAxis(deltaAngle, AircraftConfiguration.bankAxis);
            transform.rotation *= rotation;
        }
        protected virtual void YawRotation()
        {
            var deltaAngle = inputChannel.Yaw * AircraftConfiguration.yawMaxSpeed * Time.deltaTime;
            var rotation = Quaternion.AngleAxis(deltaAngle, AircraftConfiguration.yawAxis);
            transform.rotation *= rotation;
        }
       
    }
}