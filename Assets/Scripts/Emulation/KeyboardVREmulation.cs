using Gameplay.Channels;
using UnityEngine;

namespace Emulation
{
    public class KeyboardVREmulation : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private InputChannel inputChannel;
        
        [Header("Bank/Крен")]
        [SerializeField] private KeyCode bankLeft;
        [SerializeField] private KeyCode bankRight;

        [Header("Pitch/Тангаж")]
        [SerializeField] private KeyCode pitchUp;
        [SerializeField] private KeyCode pitchDown;

        [Header("Yaw/Рыскание")] 
        [SerializeField] private KeyCode yawLeft;
        [SerializeField] private KeyCode yawRight;
        [Header("Speed")]
        [SerializeField] private KeyCode speedUp;
        [SerializeField] private KeyCode speedDown;
        private void Update()
        {
            ProcessInput();
        }

        private void ProcessInput()
        {
            var pitch = ProcessInputValue(pitchUp, pitchDown);
            var bank = ProcessInputValue(bankLeft, bankRight);
            var yaw = ProcessInputValue(yawLeft, yawRight);
            var speed = ProcessInputValue(speedUp, speedDown);
            inputChannel.UpdatePitch(pitch);
            inputChannel.UpdateBank(bank);
            inputChannel.UpdateYaw(yaw);
            if (speed != 0)
            {
                inputChannel.ChangeSpeed(speed);
            }
        }

        private float ProcessInputValue(KeyCode positive, KeyCode negative)
        {
            var pSuccess = Input.GetKey(positive);
            var nSuccess = Input.GetKey(negative);
            return nSuccess switch
            {
                true when pSuccess => 0,
                true => -1,
                _ => pSuccess ? 1 : 0
            };
        }
        
    }
}