using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject card;
    public GameObject butterflyCard;
    public GameObject hareCard;
    public GameObject snakeCard;
    public GameObject wolfCard;
    public GameObject bearCard;

    public Card.CardType cardType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject DrawCard()
    {
        cardType = (Card.CardType)Random.Range(1, 5);
        switch (cardType)
        {
            case Card.CardType.Butterfly:
                return butterflyCard;
            case Card.CardType.Hare:
                return hareCard;
            case Card.CardType.Snake:
                return snakeCard;
            case Card.CardType.Wolf:
                return wolfCard;
            case Card.CardType.Bear:
                return bearCard;
            default:
                return card;
        }
    }
}
