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

    public const float butterflyCardThreshold = 0.2f;
    public const float hareCardThreshold = 0.5f;
    public const float snakeCardThreshold = 0.65f;
    public const float wolfCardThreshold = 0.9f;
    public const float bearCardThreshold = 1f;

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
        float drawVal = Random.Range(0f, 1f);
        switch (drawVal)
        {
            case < butterflyCardThreshold:
                return butterflyCard;
            case < hareCardThreshold:
                return hareCard;
            case < snakeCardThreshold:
                return snakeCard;
            case < wolfCardThreshold:
                return wolfCard;
            case <= bearCardThreshold:
                return bearCard;
            default:
                return card;
        }
    }
}
