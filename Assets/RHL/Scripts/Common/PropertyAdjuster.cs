using UnityEngine;

namespace RHL.Scripts.Common
{
    public class PropertyAdjuster : MonoBehaviour
    {
        [SerializeField]
        private Color color;
        private Color originalColor;

        private Renderer thisRenderer;

        [SerializeField]
        private float largerSizeMultiplier = 1.1f;

        private Vector3 originalSize;

        private void Start()
        {
            thisRenderer = GetComponent<Renderer>();
            originalColor = thisRenderer.material.color;
            originalSize = transform.localScale;
        }

        public void ChangeMaterialColor()
        {
            thisRenderer.material.color = color;
        }

        public void ResetMaterialColor()
        {
            thisRenderer.material.color = originalColor;
        }

        public void ToggleSize()
        {
            if (transform.localScale == originalSize)
            {
                transform.localScale *= largerSizeMultiplier;
            }
            else
            {
                transform.localScale = originalSize;
            }
        }

        public void ToggleMaterialColor()
        {
            if (thisRenderer.material.color == originalColor)
            {
                ChangeMaterialColor();
            }
            else
            {
                ResetMaterialColor();
            }
        }
    }
}