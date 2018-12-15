using UnityEngine;

namespace RHL.Scripts.Common.Properties
{
    public class ColorAdjust : MonoBehaviour
    {
        [SerializeField]
        private Color color;
        private Color originalColor;

        private Renderer thisRenderer;

        private void Start()
        {
            thisRenderer = GetComponent<Renderer>();
            originalColor = thisRenderer.material.color;
        }

        public void ChangeMaterialColor()
        {
            thisRenderer.material.color = color;
        }

        public void ResetMaterialColor()
        {
            thisRenderer.material.color = originalColor;
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