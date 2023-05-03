using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearCard : Card
{
    public BearCard()
    {
        cardName = "Bear";
        cardType = CardType.Bear;
        healthVal = 6;
        attackVal = 3;
    }
}
