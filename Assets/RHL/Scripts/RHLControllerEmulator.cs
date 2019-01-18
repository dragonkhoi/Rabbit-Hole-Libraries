using System.Collections;
using UnityEngine;

/// <summary>
/// The Rabbit Hole Library Controller Emulator
/// emulates the usage of an Oculus Go remote.
/// </summary>
namespace RHL.Scripts.Common
{
    public class RHLControllerEmulator : MonoBehaviour
    {
        [SerializeField]
        private Transform controller;

        [SerializeField]
        private GameObject oculusGoRemote;

        private void Start()
        {
            StartCoroutine(ActivateGoRemote());
        }

        /// <summary>
        /// Function ActivateGoRemote() is a coroutine that
        /// nullifies the OVR constraints and activates the 
        /// controller and places it in an estimated arm position.
        /// </summary>
        /// <returns></returns>
        private IEnumerator ActivateGoRemote()
        {
            yield return new WaitForSeconds(0.1f);
            oculusGoRemote.SetActive(true);
            // Arm is a little lower than the head and in front
            oculusGoRemote.transform.position += new Vector3(0f, -0.3f, 0.4f);
        }

        // Update is called once per frame
        void Update()
        {
            // Rotates the controller anchor (TrackedRemote) based on arrow keys
            if (Input.GetKey(KeyCode.UpArrow))
            {
                controller.Rotate(new Vector3(-1f, 0f, 0f), Space.Self);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                controller.Rotate(new Vector3(1f, 0f, 0f), Space.Self);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                controller.Rotate(new Vector3(0f, -1f, 0f), Space.World);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                controller.Rotate(new Vector3(0f, 1f, 0f), Space.World);
            }
        }
    }
}