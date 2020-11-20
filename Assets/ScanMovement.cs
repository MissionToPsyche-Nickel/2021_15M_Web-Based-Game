using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) 
        {
                this.transform.Rotate(25 * -Vector3.right * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
                this.transform.Rotate(25 * Vector3.right * Time.deltaTime, Space.Self);
        }
    }
}
