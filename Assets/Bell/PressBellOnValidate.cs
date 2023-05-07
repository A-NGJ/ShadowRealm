using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PressBellOnValidate : MonoBehaviour
{
    public float pushForce;
    // Start is called before the first frame update
    void Start()
    {
        XRSimpleInteractable interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(PressBell);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressBell(SelectEnterEventArgs arg)
    {
        GetComponent<Rigidbody>().AddForce(-1 * transform.up * pushForce);
    }
}
