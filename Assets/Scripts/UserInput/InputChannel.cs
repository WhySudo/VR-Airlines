using UnityEngine;
using UserInput.Events;

namespace UserInput
{
    [CreateAssetMenu(fileName = "inputChannel", menuName = "Channels/Input", order = 0)]
    public class InputChannel : ScriptableObject
    {
        // public readonly BankAngleUpdatedEvent BankAngleUpdatedEvent = new BankAngleUpdatedEvent();//Крен
        // public readonly PitchAngleUpdatedEvent PitchAngleUpdatedEvent = new PitchAngleUpdatedEvent();//Тангаж
        // public readonly YawAngleUpdatedEvent YawAngleUpdatedEvent = new YawAngleUpdatedEvent();//рыскание
        public readonly ChangeSpeedRequestEvent ChangeSpeedRequestEvent = new ChangeSpeedRequestEvent();
        
        private float _bank = 0;
        private float _yaw = 0;
        private float _pitch = 0;
        
        private bool autoAlign = false;
        
        public float Bank => _bank;
        public float Yaw => _yaw;
        public float Pitch => _pitch;

        public bool AutoAlign
        {
            get => autoAlign;
            set
            {
                autoAlign = value;
            }
        } 
        
        public void UpdateBank(float newAngle)
        {
            _bank = Mathf.Clamp(newAngle, -1, 1); 
            // BankAngleUpdatedEvent.Invoke(new AngleChangedArgs(newAngle));
        }
        public void UpdatePitch(float newAngle)
        {
            _pitch = Mathf.Clamp(newAngle, -1, 1);
            // PitchAngleUpdatedEvent.Invoke(new AngleChangedArgs(newAngle));
        }
        public void UpdateYaw(float newAngle)
        {
            _yaw = Mathf.Clamp(newAngle, -1, 1);
            // YawAngleUpdatedEvent.Invoke(new AngleChangedArgs(newAngle));
        }

        public void ChangeSpeed(float delta)
        {
            ChangeSpeedRequestEvent.Invoke(new ChangeSpeedRequestArgs(delta));
        }
        
    }
    
}