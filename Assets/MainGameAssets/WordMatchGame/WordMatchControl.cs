using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordMatchControl : MonoBehaviour
{
    // Simple lock to prevent multiple word presses. When a word is clicked this is set to true. On clicking a definition will check if this is true before painting line.
    public bool wordWasClicked;
    private Transform[] points;

    public GameObject word1;
    public GameObject definition1;

    // The word and definition objects
    private int[] selectedPair;
    private int[] playerChoices;
    private int[] answerKey;
    
    // To create a line from current word to definition
    private LineRenderer lineRenderer;
    private Vector3 startPosition;
    private Vector3 mousePosition;
    private Vector3 endPosition;


    // Start is called before the first frame update
    void Start()
    {
        wordWasClicked = false;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;

        // Simple arrays to hold player choices and answer key
        selectedPair = new int[2] {0,0};
        playerChoices = new int[6] {0,0,0,0,0,0};
        answerKey = new int[] {1,1,0,0,0,0};
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
    }

    public void wordClicked(int wordNum) {
        Debug.Log("Word" + wordNum + " clicked.");

        // Set this value as first pair value and clear second pair value
        selectedPair[0] = wordNum;
        selectedPair[1] = 0;

        
        wordWasClicked = true;
        startPosition = GameObject.Find("word" + wordNum).transform.position;
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, mousePosition);   

        if (!lineRenderer.enabled) {
            lineRenderer.enabled = true;
        }
     
        
        // Set start position as edge of this object and then draw line
        //makeLine();
    }

    public void definitionClicked(int defNum) {
        Debug.Log("Definition" + defNum + " clicked");
    }
}
