using RHL.Scripts.Model;

namespace RHL.Scripts.Interactable
{
    public class RHInteractableRayTrigger : RHInteractable
    {
        void Awake()
        {
            InteractableType = RHInteractableType.Ray;
        }

        /// <summary>
        /// Should be called by the Raycast when it hits this object,
        /// triggering the interactions that happen when the ray hits
        /// this object.
        /// </summary>
        public override void TriggerResponse()
        {
            // Call user specified interaction for [Pointed At AND Trigger Pulled] here
            InvokeInteraction();
        }
    }
}
