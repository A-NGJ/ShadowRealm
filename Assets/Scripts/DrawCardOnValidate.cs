using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrawCardOnValidate : MonoBehaviour
{
    public GameObject card;


    public Transform spawnPoint;
    public float bounceForce = 10;
    public Card.CardType cardType;
    public CardManager cardManager;

    // Start is called before the first frame update
    void Start()
    {
        XRSimpleInteractable interactable = GetComponent<XRSimpleInteractable>();
        //interactable.activated.AddListener(DrawCard);
        interactable.selectEntered.AddListener(SpawnCard);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCard(SelectEnterEventArgs arg)
    {
        GameObject card = cardManager.DrawCard();
        GameObject spawnedCard = Instantiate(card);
        spawnedCard.transform.position = spawnPoint.position;
        spawnedCard.GetComponent<Rigidbody>().AddForce(spawnPoint.up * bounceForce);
    }

}
