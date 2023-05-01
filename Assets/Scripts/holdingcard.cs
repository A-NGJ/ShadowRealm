using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class holdingcard : MonoBehaviour
{
  public InputActionProperty gripAnimationAction_left;
  public InputActionProperty gripAnimationAction_right;

  public InputActionProperty pinchAnimationAction_left;
  public InputActionProperty pinchAnimationAction_right;
  public bool hasCard = false;
  public CardBehaviour card = null;

  private bool isHoldingButton = false;

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
  }

  void OnTriggerEnter(Collider other)
  {
    Debug.Log("Something is colliding with the Placeholder" + other.gameObject.tag);
    if (other.gameObject.CompareTag("Card") && !isHoldingButton ) // && card == null
    {
      Debug.Log("PlaceHolder has a Card");
      hasCard = true;
    //   card = other.gameObject.GetComponent<CardBehaviour>();
    }
  }

  void OnTriggerExit(Collider other)
  {
    if (other.gameObject.CompareTag("Card") && isHoldingButton) // && other.gameObject.GetComponent<CardBehaviour>()==card
    {
      Debug.Log("Placeholder does not have a card anymore");
    //   card = null; 
      hasCard = false;

    }
  }

}

