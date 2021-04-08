using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordMatchControl : MonoBehaviour
{
    // Simple lock to prevent multiple word presses. When a word is clicked this is set to true. On clicking a definition will check if this is true before painting line.
    private static bool wordWasClicked;

    // The GameObject for Scene Transitions
    private GameObject sceneTransition;

    // replace this with something more elegant soon
    public GameObject[] words;
    public GameObject[] definitions;
    public LineRenderer[] lines;

    // The word and definition objects
    private static int selection;
    private static int[] playerChoices;
    private int[] answerKey = new int[] {1,1,2,2,3,3};
    
    // To create a line from current word to definition

    // For player message if choices are incorrect
    private Text successMessageText;
    string successMessage;

    void Start() {
        sceneTransition = GameObject.Find("SceneTransitionHolder");
        wordWasClicked = false;
        selection = 0;
        playerChoices = new int[6] {1,0,2,0,3,0};
        successMessage = ""; 
        successMessageText = GameObject.Find("SuccessMessage").GetComponentInChildren<Text>();
        successMessageText.text = successMessage;

        // setup listeners
        for (int i = 0; i < 3; i++)
        {
            int x = i + 1;
            words[i].GetComponentInChildren<Canvas>().worldCamera = Camera.main;
            words[i].GetComponentInChildren<Button>().onClick.AddListener(() => wordClicked(x));
            definitions[i].GetComponentInChildren<Canvas>().worldCamera = Camera.main;
            definitions[i].GetComponentInChildren<Button>().onClick.AddListener(() => definitionClicked(x));
        }
        updateLines();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void wordClicked(int wordNum) {
        Debug.Log("Word " + wordNum + " clicked.");
        
        //this acts as a lock to prevent multiple definitions from being selected.
        wordWasClicked = true;
        selection = wordNum;
    }

    public void definitionClicked(int defNum) {
        if (wordWasClicked) {
            Debug.Log("Definition " + defNum + " clicked while word " + selection + " selected.");

            // this is mathematically equivalent to the old switch statement, due to how the pairings work
            playerChoices[selection * 2 - 1] = defNum;
        }
        else {
            Debug.Log("Definition " + defNum + " clicked when no word was selected.");
        } 

        wordWasClicked = false;
        updateLines();
    }

    public void updateLines()
    {
        for (int i = 0; i < 3; i++)
        {
            LineRenderer line = lines[i];
            int def = playerChoices[i * 2 + 1];
            if (def == 0) // is there data here? no?
            {
                line.enabled = false;
            }
            else
            {
                line.SetPosition(0, words[i].transform.position);
                line.SetPosition(1, definitions[def - 1].transform.position); // -1 since def is 1-based instead of 0-based
                line.enabled = true;
            }
        }
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
                PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
                sceneTransition.GetComponent<SceneTransition>().SceneTransitionOnClick("Journal");
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
