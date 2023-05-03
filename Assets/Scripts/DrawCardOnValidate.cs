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
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        XRSimpleInteractable interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(SpawnCard);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCard(SelectEnterEventArgs arg)
    {
        if (gameManager.player.isCardDrawn == false)
        {
            GameObject card = cardManager.DrawCard();
            GameObject spawnedCard = Instantiate(card);
            spawnedCard.transform.position = spawnPoint.position;
            spawnedCard.GetComponent<Rigidbody>().AddForce(spawnPoint.up * bounceForce);
            //gameManager.player.isCardDrawn = true;
        }
    }

}
