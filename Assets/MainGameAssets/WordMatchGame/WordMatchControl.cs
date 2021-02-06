using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordMatchControl : MonoBehaviour
{
    // Simple lock to prevent multiple word presses. When a word is clicked this is set to true. On clicking a definition will check if this is true before painting line.
    private static bool wordWasClicked;
    private Transform[] points;

    // The GameObject for Scene Transitions
    private GameObject sceneTransition;

    public GameObject word1;
    public GameObject word2;
    public GameObject word3;
    public GameObject definition1;
    public GameObject definition2;
    public GameObject definition3;
    public GameObject startPositionHolder;

    // The word and definition objects
    private static int selection;
    private static int[] playerChoices;
    private int[] answerKey = new int[] {1,1,2,2,3,3};
    
    // To create a line from current word to definition
    public LineRenderer lineRenderer;
    private Transform startPosition;
    private Vector3 mousePosition;
    private Transform endPosition;

    // For player message if choices are incorrect
    private TextMeshProUGUI successMessageText;
    string successMessage;

    void Start() {
        startPosition = startPositionHolder.transform;
        sceneTransition = GameObject.Find("SceneTransitionHolder");
        wordWasClicked = false;
        selection = 0;
        playerChoices = new int[6] {1,0,2,0,3,0};
        successMessage = ""; 
        successMessageText = GameObject.Find("SuccessMessage").GetComponent<TextMeshProUGUI>();
        successMessageText.text = successMessage;
    }

    // Update is called once per frame
    void Update()
    {
        // Track mouse position after player click
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Create list of positions to store updated line renderer positions
        List<Vector3> pos = new List<Vector3>();
        pos.Add(word1.transform.position);
        pos.Add(definition1.transform.position);
        lineRenderer.startWidth = 1f;
        lineRenderer.endWidth = 1f;
        // Update the line renderer positions to the new ones from the list
        lineRenderer.SetPositions(pos.ToArray());
    }

    public void word1Clicked() {
        Debug.Log("Word 1 clicked.");
        
        //this acts as a lock to prevent multiple definitions from being selected.
        wordWasClicked = true;
        selection = 1;

        
        startPosition = word1.transform;
        /**
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

                // Display success message to player then change scenes
                successMessage = "Great Job!";
                successMessageText.text = successMessage;
                sceneTransition.GetComponent<SceneTransition>().LoadNewScene("Main");
            } else {
                Debug.Log("Wrong.");

                // Display message to player that this was incorrect
                successMessage = "Try Again";
                successMessageText.text = successMessage;
            }
        }
        else {
            Debug.Log("Tried to check answers when word was selected.");
            //Give reminder to player to make a selection
        }
    }
}
