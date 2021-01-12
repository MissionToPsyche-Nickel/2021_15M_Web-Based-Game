using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordMatchControl : MonoBehaviour
{
    // Simple lock to prevent multiple word presses. When a word is clicked this is set to true. On clicking a definition will check if this is true before painting line.
    public bool wordWasClicked;

    // To create a line from current word to definition
    private LineRenderer lineRenderer;
    public Transform endPosition;

    Vector2 startPosition;
    Vector2 mousePosition;


    // Start is called before the first frame update
    void Start()
    {
        wordWasClicked = false;

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
    }

    void makeLine() {
        if (!lineRenderer.enabled) {
            lineRenderer.enabled = true;
        }

        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, mousePosition);
    } 

    public void firstWordClicked() {

        /**
        * 
        Notes:
        Overall scheme so far - See if this object is already connected to a definition. If not, attach lineRenderer to right outside edge of object and track mouse movement. The definition object should handle the logic of drawing the line on click. 
                
        */
        wordWasClicked = true;

        //set start position as edge of this object and then draw line
        startPosition = Word1.transform;
        makeLine();
    }

    public void firstDefinitionClicked() {

    }
}
