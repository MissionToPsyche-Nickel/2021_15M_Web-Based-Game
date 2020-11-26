using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanMovement : MonoBehaviour
{
    public GameObject scanner;
    public int angle = 1;
    public int min = 0;
    public int max = 8;

    void Update()
    {
        angle += Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) ? -1 : 0;
        angle += Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) ? 1 : 0;
        angle = Mathf.Clamp(angle, min , max);
        scanner.transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
