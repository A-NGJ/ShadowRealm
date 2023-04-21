using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CardBehaviour : MonoBehaviour
{
  private Vector3 originalPosition;
  private Vector3 Movementpostion;
  private bool isBeingHeld = false;
  private bool isHoldingButton = false;
  private float moveSpeed = 5.0f;
  public InputActionProperty pinchAnimationAction;

  // Start is called before the first frame update
  void Start()
  {
    originalPosition = transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    // Check if the button is being held down
    if (pinchAnimationAction.action.ReadValue<float>() > 0.01)
    {
      isHoldingButton = true;
      // Debug.Log("It is Holding the Button" + isHoldingButton);
    }
    else
    {
      isHoldingButton = false;
      // Debug.Log("It is not Holding the button" + isHoldingButton);
    }

    Debug.Log(isHoldingButton);

    if (!isBeingHeld && Vector3.Distance(transform.position, originalPosition) > 0.1f)
    {
      transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
    }
  }

  void OnTriggerEnter(Collider other)
  {

    // If the user is pressing the button and there's a collision between hand and object, then the card must be held
    if (other.gameObject.CompareTag("Hand") && isHoldingButton)
    {
      isBeingHeld = true;
    }

  }
}
