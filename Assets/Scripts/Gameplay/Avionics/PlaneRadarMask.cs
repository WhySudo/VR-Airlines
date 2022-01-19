using UnityEngine;

namespace Gameplay.Avionics
{
    public class PlaneRadarMask : AvionicElement
    {
        [SerializeField] private RectTransform containerTransform;
        private RectTransform RectTransform => (RectTransform) transform;

        private void Update()
        {
            CalculateRadarMask();
        }

        private void CalculateRadarMask()
        {
            var size = containerTransform.rect.size;
            CalculatePitch(size);
            CalculateBank(size);
        }

        private void CalculateBank(Vector2 size)
        {
            RectTransform.localRotation = Quaternion.Euler(0, 0, planeMovement.Bank);
        }

        private void CalculatePitch(Vector2 size)
        {
            var setPitchPos = planeMovement.Pitch * size.y / 90f / 2f;
            RectTransform.anchoredPosition = new Vector2(0, setPitchPos);
        }
    }
}