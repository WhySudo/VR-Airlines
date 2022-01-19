using Gameplay.UserInput.Events;
using UnityEngine;

namespace Gameplay.Channels
{
    [CreateAssetMenu(fileName = "inputChannel", menuName = "Channels/Input", order = 0)]
    public class InputChannel : ScriptableObject
    {
        public readonly ChangeSpeedRequestEvent ChangeSpeedRequestEvent = new ChangeSpeedRequestEvent();
        
        private float _bank = 0;
        private float _yaw = 0;
        private float _pitch = 0;

        public float Bank => _bank;
        public float Yaw => _yaw;
        public float Pitch => _pitch;

        public bool AutoAlign { get; set; } = false;

        public void UpdateBank(float newAngle)
        {
            _bank = Mathf.Clamp(newAngle, -1, 1); 
        }
        public void UpdatePitch(float newAngle)
        {
            _pitch = Mathf.Clamp(newAngle, -1, 1);
        }
        public void UpdateYaw(float newAngle)
        {
            _yaw = Mathf.Clamp(newAngle, -1, 1);
        }

        public void ChangeSpeed(float delta)
        {
            ChangeSpeedRequestEvent.Invoke(new ChangeSpeedRequestArgs(delta));
        }
        
    }
    
}