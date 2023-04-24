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
  private Vector3 spacer = new Vector3(0f, 0.1f, 0f);
  public InputActionProperty gripAnimationAction;

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
    if (gripAnimationAction.action.ReadValue<float>() > 0.01)
    {
      isHoldingButton = true;
    }
    else
    {
      isHoldingButton = false;
    }

    Debug.Log(isHoldingButton);

    if (Vector3.Distance(transform.position, originalPosition) > 0.1f)
    {
      if (!isBeingHeld && !isHoldingButton)
      {
        transform.rotation = Quaternion.identity;
        if (transform.position.y < 1)
        {
          transform.position = Vector3.MoveTowards(transform.position + spacer, originalPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
          transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
        }

        isBeingHeld = false;
      }
    }

    if (!isBeingHeld && !isHoldingButton)
    {
      if (Vector3.Distance(transform.position, originalPosition) > 0.3f)
      {
        transform.rotation = Quaternion.identity;
        transform.position = Vector3.MoveTowards(transform.position + spacer, originalPosition, moveSpeed * Time.deltaTime);
      }

    }


  }

  void OnTriggerEnter(Collider other)
  {
    Debug.Log("colliding");

    if (isHoldingButton)
    {
      Debug.Log("We are grabbing the card " + isHoldingButton);
    }


    // If the user is pressing the button and there's a collision between hand and object, then the card must be held
    if (other.gameObject.CompareTag("Hand") && isHoldingButton)
    {
      Debug.Log("It is working");
      isBeingHeld = true;
    }

  }
}