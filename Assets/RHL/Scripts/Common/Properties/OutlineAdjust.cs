using UnityEngine;

namespace RHL.Scripts.Common.Properties
{
    public class OutlineAdjust : MonoBehaviour
    {
        [SerializeField]
        private float higherOutlineWidth = 0.03f;

        private float originalOutlineWidth = 0.0f;

        private Renderer thisRenderer;

        private void Start()
        {
            thisRenderer = GetComponent<Renderer>();
            originalOutlineWidth = thisRenderer.material.GetFloat("_Outline");
        }

        public void IncreaseOutlineWidth()
        {
            SetOutlineWidth(higherOutlineWidth);
        }

        public void ResetOutlineWidth()
        {
            SetOutlineWidth(originalOutlineWidth);
        }

        public void SetOutlineWidth(float widthValue)
        {
            thisRenderer.material.SetFloat("_Outline", widthValue);
        }

        public void ToggleOutlineWidth()
        {
            if (thisRenderer.material.GetFloat("_Outline") == originalOutlineWidth)
            {
                IncreaseOutlineWidth();
            }
            else
            {
                ResetOutlineWidth();
            }
        }
    }
}