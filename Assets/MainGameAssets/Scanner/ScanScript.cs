using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanScript : MonoBehaviour
{

    public Camera cam;
    public GameObject endOfTelescope;
    public LineRenderer lineRenderer1;
    public LineRenderer lineRenderer2;
    public float maximumScanningRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer1.SetPosition(0, endOfTelescope.transform.position);
        lineRenderer2.SetPosition(0, endOfTelescope.transform.position);
        
        RaycastHit hit;

        var mousePosition = Input.mousePosition;
        var rayMouse = cam.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit, maximumScanningRange)) {
            if (hit.collider) {
                lineRenderer1.SetPosition(1, hit.point);
                lineRenderer2.SetPosition(1, hit.point);
            }
        }
        else {
            var position = rayMouse.GetPoint(maximumScanningRange); 
            lineRenderer1.SetPosition(1, position); 
            lineRenderer2.SetPosition(1, position);
            }
    }
}
