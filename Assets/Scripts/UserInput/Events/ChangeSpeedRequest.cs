using UnityEngine.Events;

namespace UserInput.Events
{
    public class ChangeSpeedRequestEvent : UnityEvent<ChangeSpeedRequestArgs>
    {
    }

    public class ChangeSpeedRequestArgs
    {
        public float deltaSpeed;

        public ChangeSpeedRequestArgs(float deltaSpeed)
        {
            this.deltaSpeed = deltaSpeed;
        }
    }
}