using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class CardBehaviour : MonoBehaviour
{
    public Vector3 originalPosition;
    private Vector3 Movementpostion;
    public bool cardplayed = false;
    private bool isHoldingButton = false;

    public float moveSpeed = 5.0f;
    private Vector3 spacer = new Vector3(0f, 0.1f, 0f);
    private Quaternion originalRotation = Quaternion.Euler(0, 0, 0);
    public InputActionProperty gripAnimationAction_left;
    public InputActionProperty gripAnimationAction_right;

    public InputActionProperty pinchAnimationAction_left;
    public InputActionProperty pinchAnimationAction_right;

    public Vector3 placeHolderPosition;
    public Vector3 opponentPlaceHolderPosition;
    public Vector3 HandPlaceHolderPosition;
    public Vector3 playerSacrificePilePosition;
    public XRGrabInteractable grabInteractable;
    public Card card;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        grabInteractable = GetComponent<XRGrabInteractable>();
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

        // Check if the card is far away from the table
        if (Vector3.Distance(transform.position, originalPosition) > 0.1f)
        {
            // Check if the user is holding the button
            if (!isHoldingButton)
            {
                // Fix the rotation of the card so it doesn't collide with the table in a weird way.
                transform.rotation = originalRotation;

                // Check the distance with the last placeholder the user has interacted with. 
                // If the distance with that placeholder is below x move the card towards the placeholder.
                if (Vector3.Distance(transform.position, placeHolderPosition) < 0.1f && !cardplayed)
                {
                    // Debug.Log("Moving towards placeholder " + placeHolderPosition);
                    transform.position = Vector3.MoveTowards(transform.position, placeHolderPosition, moveSpeed * Time.deltaTime);
                    cardplayed = true;
                    grabInteractable.enabled = false;
                }
                /*
                if (Vector3.Distance(transform.position, playerSacrificePilePosition) < 0.1f && !cardplayed)
                {
                    // Debug.Log("Moving towards placeholder " + placeHolderPosition);
                    transform.position = Vector3.MoveTowards(transform.position, playerSacrificePilePosition, moveSpeed * Time.deltaTime);
                    cardplayed = true;
                    grabInteractable.enabled = false;
                }
                */
                if (Vector3.Distance(transform.position, HandPlaceHolderPosition) < 0.2f && !cardplayed)
                {
                    // Debug.Log("Moving towards Hand placeholder");
                    transform.position = Vector3.MoveTowards(transform.position, HandPlaceHolderPosition, moveSpeed * Time.deltaTime);
                    originalPosition = HandPlaceHolderPosition;
                }

                // If the card it's far from the placeholder, move the card towards the original position.
                // If the card is below the table, add some height to the card to avoid collision.
                else if (transform.position.y < 1 && !cardplayed)
                {
                    // Debug.Log("Moving to original position spacer");
                    transform.position = Vector3.MoveTowards(transform.position + spacer, originalPosition, moveSpeed * Time.deltaTime);
                }
                // Otherwaise just move the card to the original position
                else if (!cardplayed)
                {
                    // Debug.Log("Moving to original position");
                    transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
                }
            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        // If the user is pressing the button and there's a collision between hand and object, then the card must be held
        if (other.gameObject.CompareTag("Card-placeholder") && isHoldingButton)
        {
            placeHolderPosition = other.transform.position;
            // Debug.Log("Colliding with placeholder" + placeHolderPosition);

        }

        if (other.gameObject.CompareTag("Hand-placeholder") && isHoldingButton)
        {
            HandPlaceHolderPosition = other.transform.position;
            // Debug.Log("Colliding with Handplaceholder" + HandPlaceHolderPosition);
        }

        if (other.gameObject.CompareTag("sacrifice-placeholder") && isHoldingButton)
        {
            playerSacrificePilePosition = other.transform.position;
            // Debug.Log("Colliding with Handplaceholder" + HandPlaceHolderPosition);
        }

    }
}