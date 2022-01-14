using UnityEngine;
using UnityEngine.Events;

namespace UserInput.Events
{
    public class PitchAngleUpdatedEvent : UnityEvent<AngleChangedArgs>
    {
    }

    public class AngleChangedArgs
    {
        public float deltaAngle;

        public AngleChangedArgs(float deltaAngle)
        {
            this.deltaAngle = Mathf.Clamp(deltaAngle, -1, 1);
        }
    }
}