using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanMovement : MonoBehaviour
{
    public GameObject scanner;
    public GameObject twinkle;
    public int angle = 1;
    public int min = 0;
    public int max = 8;
    public float tolerance = 5f; // tolerance, in degrees
    [HideInInspector]
    public bool seeing = false; // boolean saying if the scope can "see" the twinkle

    void Update()
    {
        angle += Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) ? -1 : 0;
        angle += Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) ? 1 : 0;
        angle = Mathf.Clamp(angle, min , max);
        scanner.transform.eulerAngles = new Vector3(0, 0, angle);

        float ang = (50 + 2 * angle) / 3f; // this manages to convert the input range (-85, 10) to an angle good for calculations
        ang *= Mathf.PI / 180f; // convert to radians

        Vector3 delta = twinkle.transform.position - scanner.transform.position;
        float twinkAng = Mathf.Atan2(delta.y, delta.x); // this is the angle to exactly look at the twinkle's current position

        seeing = Mathf.Abs(ang - twinkAng) < (tolerance * Mathf.PI / 180f);

        Debug.DrawRay(scanner.transform.position, new Vector3(Mathf.Cos(ang), Mathf.Sin(ang)), seeing ? Color.green : Color.red);
        Debug.DrawRay(scanner.transform.position, new Vector3(Mathf.Cos(twinkAng), Mathf.Sin(twinkAng)), Color.blue);
    }
}
