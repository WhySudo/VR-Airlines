using UnityEngine;

namespace Gameplay.UserInput.TrackableRig
{
    public class TrackableJoystickShadow : MonoBehaviour
    {
        [SerializeField] private TrackableJoystickRig followRig;
        [SerializeField] private GameObject view;
        private void Update()
        {
            if (followRig.InputLocked)
            {
                view.SetActive(false);
            }
            else
            {
                view.SetActive(true);
                transform.localPosition = followRig.PivotPoint;
                transform.rotation = followRig.transform.rotation;
            }
        }
    }
}