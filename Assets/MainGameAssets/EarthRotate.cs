using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script can be used to make the earth object rotate around a central axis.

@author Jacob Bement
@version 11/4/20
*/
public class EarthRotate : MonoBehaviour
{
    //used to set the speed of the rotation
    float speed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
