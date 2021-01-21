using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordMatchControl : MonoBehaviour
{
    // Simple lock to prevent multiple word presses. When a word is clicked this is set to true. On clicking a definition will check if this is true before painting line.
    private static bool wordWasClicked;
    private Transform[] points;

    public GameObject word1;
    public GameObject definition1;

    // The word and definition objects
    private static int selection;
    private static int[] playerChoices;
    private int[] answerKey = new int[] {1,1,2,2,3,3};
    
    // To create a line from current word to definition
    //private LineRenderer lineRenderer;
    private Transform startPosition;
    private Vector3 mousePosition;
    private Transform endPosition;

    void Start() {
        wordWasClicked = false;
        selection = 0;
        playerChoices = new int[6] {1,0,2,0,3,0};
    }

    // Update is called once per frame
    void Update()
    {
        // Track mouse position after player click
        //mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);  
    }

    public void word1Clicked() {
        Debug.Log("Word 1 clicked.");
        
        //this acts as a lock to prevent multiple definitions from being selected.
        wordWasClicked = true;
        selection = 1;

        /**
        startPosition = word1.transform;
        
        if (lineRenderer == null) {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        lineRenderer.SetPosition(0, startPosition.position);
        lineRenderer.SetPosition(1, mousePosition);  
        lineRenderer.useWorldSpace = true; 

        if (!lineRenderer.enabled) {
            lineRenderer.enabled = true;
        }
        */  
    }

    public void word2Clicked() {
        Debug.Log("Word 2 clicked.");
        wordWasClicked = true;
        selection = 2;
    }

    public void word3Clicked() {
        Debug.Log("Word 3 clicked.");
        wordWasClicked = true;
        selection = 3;
    }

    public void definitionClicked(int defNum) {
        if (wordWasClicked) {
            Debug.Log("Definition " + defNum + " clicked while word " + selection + " selected.");

            switch (selection) {

                case 1:
                playerChoices[1] = defNum;
                break;

                case 2:
                playerChoices[3] = defNum;
                break;

                case 3:
                playerChoices[5] = defNum;
                break;
            }
        }
        else {
            Debug.Log("Definition clicked when no word was selected.");
        } 

        wordWasClicked = false;

        //lineRenderer.enabled = false;
    }

    public void checkAnswers() {
        if (!wordWasClicked) {
            bool isCorrect = true;
            for (int i = 0; i < answerKey.Length; i++) {
                if (playerChoices[i] != answerKey[i]) {
                    isCorrect = false;
                }
            }
            if (isCorrect) {
                Debug.Log("All answers are correct.");
            } else {
                Debug.Log("Wrong.");
            }
        }
        else {
            Debug.Log("Tried to check answers when word was selected.");
            //Give reminder to player to make a selection
        }
    }
}
