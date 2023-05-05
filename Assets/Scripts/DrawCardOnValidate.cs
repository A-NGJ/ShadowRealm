using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrawCardOnValidate : MonoBehaviour
{
    public GameObject card;


    public Transform spawnPoint;
    public float bounceForce = 10;
    public int drawLimit = 2;
    public int drawCount = 0;
    public Card.CardType cardType;
    public CardManager cardManager;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        XRSimpleInteractable interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(SpawnCard);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCard(SelectEnterEventArgs arg)
    {
        if (gameManager.player.isCardDrawn == false)
        {
            drawCount += 1;
            GameObject card = cardManager.DrawCard();
            GameObject spawnedCard = Instantiate(card);
            spawnedCard.transform.position = spawnPoint.position;
            spawnedCard.GetComponent<Rigidbody>().AddForce(spawnPoint.up * bounceForce);
            if (drawCount >= drawLimit)
            {
                gameManager.player.isCardDrawn = true;
                drawCount = 0;
            }
            Debug.Log(GameObject.Find ("DeckCanvas"));
            if (GameObject.Find("DeckCanvas") != null){
                Destroy (GameObject.Find ("DeckCanvas"));
            }

            if (GameObject.Find("CanvasBell") != null){
                Destroy (GameObject.Find ("CanvasBell"));
            }
            
        }
    }

}
