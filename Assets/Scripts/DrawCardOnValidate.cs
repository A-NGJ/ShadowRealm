using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrawCardOnValidate : MonoBehaviour
{
    public GameObject card;
    public GameObject butterflyCard;
    public GameObject hareCard;
    public GameObject snakeCard;
    public GameObject wolfCard;
    public GameObject bearCard;

    public Transform spawnPoint;
    public float bounceForce = 10;
    public Card.CardType cardType;

    // Start is called before the first frame update
    void Start()
    {
        XRSimpleInteractable interactable = GetComponent<XRSimpleInteractable>();
        //interactable.activated.AddListener(DrawCard);
        interactable.selectEntered.AddListener(DrawCard);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawCard(SelectEnterEventArgs arg)
    {
        GameObject spawnedCard;
        cardType = (Card.CardType)Random.Range(1, 5);
        if (cardType == Card.CardType.Butterfly)
        {
            spawnedCard = Instantiate(butterflyCard);
        }
        else if (cardType == Card.CardType.Hare)
        {
            spawnedCard = Instantiate(hareCard);
        }
        else if (cardType == Card.CardType.Snake)
        {
            spawnedCard = Instantiate(snakeCard);
        }
        else if (cardType == Card.CardType.Wolf)
        {
            spawnedCard = Instantiate(wolfCard);
        }
        else if (cardType == Card.CardType.Bear)
        {
            spawnedCard = Instantiate(bearCard);
        }
        else
        {
            spawnedCard = Instantiate(card);
        }
        spawnedCard.transform.position = spawnPoint.position;
        spawnedCard.GetComponent<Rigidbody>().AddForce(spawnPoint.up * bounceForce);
    }
}
