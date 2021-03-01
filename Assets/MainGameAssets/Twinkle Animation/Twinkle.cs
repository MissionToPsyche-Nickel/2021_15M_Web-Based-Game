using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twinkle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(
            Random.Range(0.0f, 8.0f),
            Random.Range(-4.0f, 4.0f),
            -1
        );

        // visibility modifier based on difficulty probably goes here
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

