using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RHL.Scripts.Interactable;
using UnityEngine.Events;

namespace RHL.Scripts.InputSystem
{
    public class RHControllerBase : MonoBehaviour
    {
        [SerializeField]
        private bool CheckRayHit = true;

        [SerializeField]
        private bool CheckRayExit = true;

        [SerializeField]
        private bool CheckRayTrigger = true;

        [SerializeField]
        private KeyCode simulatedTriggerKey = KeyCode.Space;

        private GameObject lastObjectInteracted;

        public UnityEvent OnRayHitInteractable;
        public UnityEvent OnRayExitInteractable;

        // public UnityEvent On

        public bool RayHitInteractable { get; set; }

        public bool TriggerPulled
        {
            private set
            {
                TriggerPulled = value;
            }
            get
            {
                return OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || UnityEngine.Input.GetKeyDown(simulatedTriggerKey);
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            RayHitInteractable = false;

            if (CheckRayHit || CheckRayExit || CheckRayTrigger)
            {
                RaycastHit raycastHit;
                // Does the ray intersect any objects
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycastHit, Mathf.Infinity))
                {
                    // Ensure that the ray is hitting a new object
                    if (CheckRayHit && lastObjectInteracted != raycastHit.transform.gameObject)
                    {
                        // Trigger exit on old object if the two were overlapping
                        if (CheckRayExit)
                        {
                            SendRayExit();
                        }
                        lastObjectInteracted = raycastHit.transform.gameObject;
                        RHInteractableRayHit interactableRayHit = lastObjectInteracted.GetComponent<RHInteractableRayHit>();
                        if (interactableRayHit != null)
                        {
                            interactableRayHit.TriggerResponse();
                        }
                        if (lastObjectInteracted.GetComponent<RHInteractable>() != null)
                        {
                            RayHitInteractable = true;
                            OnRayHitInteractable.Invoke();
                        }
                    }
                    // If we are checking for trigger interaction
                    if (CheckRayTrigger)
                    {
                        // The raycast hit, now check if trigger pulled
                        if (TriggerPulled)
                        {
                            lastObjectInteracted = raycastHit.transform.gameObject;
                            RHInteractableRayTrigger interactableRayTrigger = lastObjectInteracted.GetComponent<RHInteractableRayTrigger>();
                            if (interactableRayTrigger != null)
                            {
                                interactableRayTrigger.TriggerResponse();
                            }
                        }
                    }
                    // If only CheckRayExit interactions activated, we still need to record interaction
                    lastObjectInteracted = raycastHit.transform.gameObject;
                }
                else
                {
                    // The raycast did not hit anything
                    if (CheckRayExit)
                    {
                        SendRayExit();
                    }
                }
            }
        }

        private void SendRayExit()
        {
            // Ensure that the ray was previously hitting an object
            if (lastObjectInteracted != null)
            {
                RHInteractableRayExit interactableRayExit = lastObjectInteracted.GetComponent<RHInteractableRayExit>();
                if (interactableRayExit != null)
                {
                    interactableRayExit.TriggerResponse();
                }
                lastObjectInteracted = null;
                OnRayExitInteractable.Invoke();
            }
        }
    }
}
