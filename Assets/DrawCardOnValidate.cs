using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrawCardOnValidate : MonoBehaviour
{
    public GameObject card;
    public Transform spawnPoint;
    public float bounceForce = 10;

    // Start is called before the first frame update
    void Start()
    {
        XRSimpleInteractable interactable = GetComponent<XRSimpleInteractable>();
        interactable.activated.AddListener(DrawCard);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawCard(ActivateEventArgs arg)
    {
        GameObject spawnedCard = Instantiate(card);
        spawnedCard.transform.position = spawnPoint.position;
        spawnedCard.GetComponent<Rigidbody>().AddForce(spawnPoint.up * bounceForce);
    }
}
