using UnityEngine;

namespace RHL.Scripts.Common.Properties
{
    public class TransparencyAdjust : MonoBehaviour
    {
        [SerializeField]
        private float higherAlpha = 0.4f;

        private float originalRendererAlpha;

        private Renderer thisRenderer;

        private void Start()
        {
            thisRenderer = GetComponent<Renderer>();
            originalRendererAlpha = thisRenderer.material.color.a;
        }

        public void IncreaseAlpha()
        {
            SetAlpha(higherAlpha);            
        }

        public void ResetAlpha()
        {
            SetAlpha(originalRendererAlpha);
        }

        public void SetAlpha(float alphaValue)
        {
            Color tempColor = thisRenderer.material.color;
            thisRenderer.material.color = new Color(tempColor.r, tempColor.g, tempColor.b, alphaValue);
        }

        public void ToggleAlphaAdjust()
        {
            if (thisRenderer.material.color.a == originalRendererAlpha)
            {
                IncreaseAlpha();
            }
            else
            {
                ResetAlpha();
            }
        }
    }
}