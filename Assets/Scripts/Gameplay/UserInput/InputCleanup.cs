using Gameplay.Channels;
using UnityEngine;

namespace Gameplay.UserInput
{
    public class InputCleanup : MonoBehaviour
    {
        [SerializeField] private InputChannel inputChannel;

        private void Awake()
        {
            inputChannel.ChangeSpeed(0);
            inputChannel.UpdateYaw(0);
            inputChannel.UpdatePitch(0);
            inputChannel.UpdateBank(0);
        }
    }
}