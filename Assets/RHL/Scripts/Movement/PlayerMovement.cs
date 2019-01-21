using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RHL.Scripts.Movement {

  public class PlayerMovement : MonoBehaviour {

    private bool isWalking;
    private CharacterController character;
    private Vector2 primayTouchpadPos;

    [SerializeField] private float walkingSpeed = 5.0f;

    private static OVRInput.Controller Controller {
      get {
          OVRInput.Controller controller = OVRInput.GetConnectedControllers();
          if ((controller & OVRInput.Controller.LTrackedRemote) == OVRInput.Controller.LTrackedRemote) {
              return OVRInput.Controller.LTrackedRemote;
          } else if ((controller & OVRInput.Controller.RTrackedRemote) ==  OVRInput.Controller.RTrackedRemote) {
              return OVRInput.Controller.RTrackedRemote;
          }
          return OVRInput.GetActiveController();
      }
    }

    // we make this public because often times we want to access it from other classes
    // AND we want set it from the inspector
    public bool WalkingAllowed = true;

    public bool IsWalking {
      get { return isWalking; }
      private set { isWalking = value; }
    }

  	void Start () {
      character = GetComponent<CharacterController>();

      if (character == null) {
        Debug.Log("Couldn't find CharacterController. Make sure this GameObject has a CharacterController script.");
      }	
  	}
  	
  	void Update () {
  		if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad) && WalkingAllowed) {
        controllerRotation = OVRInput.GetLocalControllerRotation(Controller);

        primayTouchpadPos = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        Vector3 movementDirection = new Vector3(primayTouchpadPos.x, 0.0f, primayTouchpadPos.y);
        Vector3 movement = controllerRotation * movementDirection;
       
        character.SimpleMove(movement * walkingSpeed);

        IsWalking = true;
      } else {
        IsWalking = false;
      }
  	}
  }
}
