using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCard : Card
{
    public SnakeCard()
    {
        cardName = "Snake";
        cardType = CardType.Snake;
        healthVal = 1;
        attackVal = 3;
    }
}
