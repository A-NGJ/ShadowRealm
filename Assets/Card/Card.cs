using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    public enum CardType
    {
        Butterfly,
        Hare,
        Snake,
        Wolf,
        Bear,
    }

    public string cardName = "Card";
    public CardType cardType;
    public int healthVal = 0;
    public int attackVal = 0;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI cardTitle;

    void Start()
    {
        healthText.text = string.Format("H: {0}", healthVal);
        attackText.text = string.Format("A: {0}", attackVal);
        cardTitle.text = cardName;
    }

    void Update()
    {
        healthText.text = string.Format("H: {0}", healthVal);
        attackText.text = string.Format("A: {0}", attackVal);
    }
}
