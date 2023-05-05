using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class CardHolder : MonoBehaviour
{
    public InputActionProperty gripAnimationAction_left;
    public InputActionProperty gripAnimationAction_right;

    public InputActionProperty pinchAnimationAction_left;
    public InputActionProperty pinchAnimationAction_right;
    public bool hasCard = false;
    public GameObject heldCard;
    private AudioSource cardSound;
    //public CardBehaviour card = null;

    private bool isHoldingButton = false;

    void Start()
    {
       // get the audio source from the child
         cardSound = GetComponentInChildren<AudioSource>(); 
         Debug.Log(cardSound);
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
        
        
    }

    void OnTriggerStay(Collider other)
    {
        // Debug.Log("Is staying the object" + other.gameObject.tag);
        //Debug.Log("Something is colliding with the Placeholder" + other.gameObject.tag);
        if (other.gameObject.CompareTag("Card") && !isHoldingButton && !hasCard) // && card == null
        {   
            
            // Debug.Log(this.gameObject.name +" has a Card");
            hasCard = true;
            heldCard = other.gameObject;
            cardSound.Play();
            //   card = other.gameObject.GetComponent<CardBehaviour>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Card") && !isHoldingButton && hasCard) // && other.gameObject.GetComponent<CardBehaviour>()==card
        {
            Debug.Log("Placeholder does not have a card anymore");
            //   card = null; 
            hasCard = false;
            heldCard = null;
            cardSound.Play();
        }
    }

}

