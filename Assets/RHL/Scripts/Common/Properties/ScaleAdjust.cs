using UnityEngine;

namespace RHL.Scripts.Common.Properties
{
    public class ScaleAdjust : MonoBehaviour
    {
        [SerializeField]
        private float largerSizeMultiplier = 1.05f;

        private Vector3 originalSize;

        private void Start()
        {
            originalSize = transform.localScale;
        }

        public void IncreaseSize()
        {
            transform.localScale *= largerSizeMultiplier;
        }

        public void ResetSize()
        {
            transform.localScale = originalSize;
        }

        public void ToggleSize()
        {
            if (transform.localScale == originalSize)
            {
                IncreaseSize();
            }
            else
            {
                ResetSize();
            }
        }
    }
}