public class ObjectInteraction : MonoBehaviour
{
    public GameObject placementArea;

    private bool isBeingHeld = false;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (isBeingHeld)
        {
            // check if the object has been released
            if (/* add your own condition here */)
            {
                if (placementArea.GetComponent<Collider>().bounds.Contains(transform.position))
                {
                    // snap the object to the placement area
                    transform.position = placementArea.transform.position;
                }
                else
                {
                    // return the object to its original position
                    transform.position = originalPosition;
                }

                isBeingHeld = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // check if the object has been grabbed by the player
        if (/* add your own condition here */)
        {
            isBeingHeld = true;
        }
    }
}
