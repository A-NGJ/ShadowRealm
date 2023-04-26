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
  public InputActionProperty gripAnimationAction_left;
  public InputActionProperty gripAnimationAction_right;

  public InputActionProperty pinchAnimationAction_left;
  public InputActionProperty pinchAnimationAction_right;

  public Vector3 placeHolderPosition;


  // Start is called before the first frame update
  void Start()
  {
    originalPosition = transform.position;
  }

  // Update is called once per frame
  void Update()
  {

    // Check if the button is being held down
    if (gripAnimationAction_left.action.ReadValue<float>() > 0.01 || gripAnimationAction_right.action.ReadValue<float>() > 0.01)
    {
      isHoldingButton = true;
    }
    else
    {
      isHoldingButton = false;
    }

    Debug.Log("The card is being held?"+isBeingHeld);

    // Check if the card is far away from the table
    if (Vector3.Distance(transform.position, originalPosition) > 0.1f)
    {
        // Check if the user is holding the button
        // TODO: Check if it is necessary isBeingHeld
        if (!isBeingHeld && !isHoldingButton)
        {
        
        // Fix the rotation of the card so it doesn't collide with the table in a weird way.
        transform.rotation = Quaternion.identity;

        // Check the distance with the last placeholder the user has interacted with. 
        // If the distance with that placeholder is below x move the card towards the placeholder.
        if (Vector3.Distance(transform.position, placeHolderPosition) < 0.1f) 
        {
            transform.position = Vector3.MoveTowards(transform.position, placeHolderPosition, moveSpeed * Time.deltaTime);
        }
        // If the card it's far from the placeholder, move the card towards the original position.
        // If the card is below the table, add some height to the card to avoid collision.
        else if (transform.position.y < 1)
        {
            transform.position = Vector3.MoveTowards(transform.position + spacer, originalPosition, moveSpeed * Time.deltaTime);
        }
        // Otherwaise just move the card to the original position
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
        }

        // TODO: Check if it is necessary
        isBeingHeld = false;
        }
    }


    // if (!isBeingHeld && !isHoldingButton)
    // {
    //     Debug.Log("other");
    //     if (Vector3.Distance(transform.position, originalPosition) > 0.3f)
    //     {
    //         transform.rotation = Quaternion.identity;
    //         transform.position = Vector3.MoveTowards(transform.position + spacer, originalPosition, moveSpeed * Time.deltaTime);
    //     }

    // }


  }

  void OnTriggerEnter(Collider other)
  {
    // Debug.Log("When colliding it is holding button? "+isHoldingButton);

    //  // If the user is pressing the button and there's a collision between hand and object, then the card must be held
    // if (other.gameObject.CompareTag("Hand") && isHoldingButton)
    // {
    //   Debug.Log("It is working");
    //   isBeingHeld = true;
    // }

         // If the user is pressing the button and there's a collision between hand and object, then the card must be held
    if (other.gameObject.CompareTag("Card-placeholder"))
    {
        
        placeHolderPosition = other.transform.position;
        Debug.Log("Colliding with placeholder" + placeHolderPosition);
    }



  }
}