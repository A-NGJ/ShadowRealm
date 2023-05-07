using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleCard : Card
{
    public TurtleCard()
    {
        cardName = "Turtle";
        cardType = CardType.Turtle;
        healthVal = 4;
        attackVal = 2;
    }
}
