using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateText1 : MonoBehaviour
{
    public float animationSpeed;
    public float upperLimit;
    public float lowerLimit;
    private  float range;
    private float startposition;

    // private float range = upperLimit - lowerLimit;

    // Start is called before the first frame update
    void Start()
    {
        range = upperLimit - lowerLimit;
        startposition = range/2; 
    }

    // Update is called once per frame
    void Update()
    {   
        if (transform.position.y >= upperLimit - 0.1f)
        {
            range = range * -1;
            // Debug.Log(range);
            // animationSpeed = animationSpeed * -1;
        }

        if (transform.position.y <= lowerLimit + 0.1f)
        {
            // Debug.Log(range);
            range = range * -1;
            // animationSpeed = animationSpeed * -1;
        }

        var endposition = new Vector3(transform.position.x, startposition + range/2, transform.position.z);
        // transform.position = new Vector3(transform.position.x, transform.position.y + (upperLimit-lowerLimit) + (animationSpeed * Time.deltaTime), transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, endposition, animationSpeed * Time.deltaTime);
    }
}

//         if (transform.position.y >= upperLimit)
//         {
//             transform.position.y = Vector3.MoveTowards(transform.position, lowerLimit, animationSpeed * Time.deltaTime);
//         }
//         else if (transform.position.y < lowerLimit)
//         {
//              transform.position.y = Vector3.MoveTowards(transform.position, upperLimit, animationSpeed * Time.deltaTime);
//         } 
//         else {}
//         transform.position = new Vector3(transform.position.x, transform.position.y + animationSpeed * Time.deltaTime, transform.position.z);
//                                 Vector3.MoveTowards(transform.position, lowerLimit, animationSpeed * Time.deltaTime);
//     }
// }
