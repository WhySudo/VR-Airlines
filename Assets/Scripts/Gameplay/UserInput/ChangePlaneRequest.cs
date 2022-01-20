using System;
using UnityEngine.Events;

namespace Gameplay.UserInput
{
    [Serializable]
    public enum ChangePlaneType
    {
        Next, Random
    }
    public class ChangePlaneRequestEvent : UnityEvent<ChangePlaneRequestArgs>
    {
    }

    public class ChangePlaneRequestArgs
    {
        public ChangePlaneType changeType;

        public ChangePlaneRequestArgs(ChangePlaneType changeType)
        {
            this.changeType = changeType;
        }
    }
}