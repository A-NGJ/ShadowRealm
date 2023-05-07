using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCardHolder : MonoBehaviour
{
    public bool hasCard = false;
    public GameObject heldCard;
    private AudioSource cardSound;

    // Start is called before the first frame update
    void Start()
    {
       cardSound = GetComponentInChildren<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("Something is colliding with the Opponent Placeholder" + other.gameObject.tag);
        if (other.gameObject.CompareTag("Card") && !hasCard)
        {
            //Debug.Log("Opponent PlaceHolder has a Card");
            hasCard = true;
            heldCard = other.gameObject;
            cardSound.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Card") && hasCard)
        {
            Debug.Log("Opponent placeholder does not have a card anymore");
            hasCard = false;
            heldCard = null;
            cardSound.Play();
        }
    }

    public void PlaySound()
    {
        cardSound.Play();
    }
}
