using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCard : Card
{
    public WolfCard()
    {
        cardName = "Wolf";
        cardType = CardType.Wolf;
        healthVal = 3;
        attackVal = 2;
    }
}
