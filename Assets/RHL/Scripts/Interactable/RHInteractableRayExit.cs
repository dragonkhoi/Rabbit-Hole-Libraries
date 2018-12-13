using RHL.Scripts.Model;

namespace RHL.Scripts.Interactable
{
    public class RHInteractableRayExit : RHInteractable
    {
        void Awake()
        {
            InteractableType = RHInteractableType.Ray;
        }

        /// <summary>
        /// Should be called by the Raycast when it stops pointing at this object,
        /// triggering the interactions that happen when the ray stops hitting
        /// this object.
        /// </summary>
        public override void TriggerResponse()
        {
            RHInteractableRayHit rayHit = GetComponent<RHInteractableRayHit>();
            if (rayHit != null)
            {
                rayHit.IsPointedAt = false;
            }

            // Call user specified interaction for [Stop Being Pointed At] here
            InvokeInteraction();
        }
    }
}
