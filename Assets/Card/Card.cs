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

    public GameObject parent;
    public string cardName = "Card";
    public CardType cardType;
    public int healthVal = 0;
    public int attackVal = 0;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI cardTitle;
    public Transform destroyPoint;
    public float moveSpeed;

    // flag values for game logic
    public bool isSummoned = false;
    public bool hasAttacked = false;
    public bool isSacrificed = false;
    public bool isPoisoned = false;
    public bool isBuffed = false;
    public bool isHibernating = false;

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

    public void Delete()
    {
        Destroy(GetComponent<CardBehaviour>());
        GetComponent<Rigidbody>().useGravity = false;
        //GetComponentInParent<Rigidbody>().AddForce(transform.up * bounceForce);
        Destroy(parent, 2f);
        transform.position = Vector3.MoveTowards(transform.position, destroyPoint.position, moveSpeed * Time.deltaTime);
        Debug.Log("Card deleted");
    }
}
