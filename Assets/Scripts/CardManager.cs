using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject card;
    public GameObject butterflyCard;
    public GameObject frogCard;
    public GameObject snakeCard;
    public GameObject turtleCard;

    public const float butterflyCardThreshold = 0.30f;
    public const float frogCardThreshold = 0.6f;
    public const float snakeCardThreshold = 0.85f;
    public const float turtleCardThreshold = 1f;

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
            case < frogCardThreshold:
                return frogCard;
            case < snakeCardThreshold:
                return snakeCard;
            case < turtleCardThreshold:
                return turtleCard;
            default:
                return card;
        }
    }
}
