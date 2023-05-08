using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogCard : Card
{
    public FrogCard()
    {
        cardName = "Frog";
        cardType = CardType.Frog;
        healthVal = 2;
        attackVal = 2;
    }
}
