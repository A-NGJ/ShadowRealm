using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCardOnStart : MonoBehaviour
{
    public CardManager cardManager;
    public Transform spawnPoint; 

    // Start is called before the first frame update
    void Start()
    {
        GameObject card = cardManager.DrawCard();
        GameObject spawnedCard = Instantiate(card);
        spawnedCard.transform.position = spawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
