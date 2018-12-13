using UnityEngine;
using RHL.Scripts.Model;
using UnityEngine.Events;

namespace RHL.Scripts.Interactable
{
    public abstract class RHInteractable : MonoBehaviour
    {
        public UnityEvent InteractionResponse;

        [Tooltip("What type of interaction will this object respond to?")]
        public RHInteractableType InteractableType;

        [Tooltip("Can you interact with this object right away?")]
        public bool InteractableOnAwake = true;

        public virtual void TriggerResponse()
        {
            InvokeInteraction();
        }

        public void InvokeInteraction()
        {
            InteractionResponse.Invoke();
        }

        protected bool CurrentlyInteractable;

        private void Awake()
        {
            if (InteractableOnAwake)
            {
                CurrentlyInteractable = true;
            }
            else
            {
                CurrentlyInteractable = false;
            }
        }
    }
}