using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDeckText : MonoBehaviour
{
    public float animationSpeed;
    public float upperLimit;
    public float lowerLimit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= upperLimit)
        {
            animationSpeed = animationSpeed * -1;
        }
        else if (transform.position.y < lowerLimit)
        {
            animationSpeed = animationSpeed * -1;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + animationSpeed * Time.deltaTime, transform.position.z);
    }
}
