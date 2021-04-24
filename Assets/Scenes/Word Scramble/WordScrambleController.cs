using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordScrambleController : MonoBehaviour
{
    public InputField InputField1;
    public InputField InputField2;
    public InputField InputField3;
    public InputField InputField4;
    public InputField InputField5;
    public Button checkAnswers;
    private Text successMessageText;
    private GameObject sceneTransition;
    string successMessage;

    public void Start()
    {
        //Adds listeners to each input field and the button to call methods when they are modified.
        InputField1.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        InputField2.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        InputField3.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        InputField4.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        InputField5.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        checkAnswers.onClick.AddListener(delegate { answersChecked(); });
        //The default success message is a blank string.
        successMessage = "";
        successMessageText = GameObject.Find("SuccessMessage").GetComponentInChildren<Text>();
        successMessageText.text = successMessage;
        //The scene transition animation.
        sceneTransition = GameObject.Find("SceneTransitionHolder");
    }
    public void ValueChangeCheck()
    {
        //Get the text from each input field and capitalize it.
        InputField1.GetComponent<InputField>().text = InputField1.GetComponent<InputField>().text.ToUpper();
        InputField2.GetComponent<InputField>().text = InputField2.GetComponent<InputField>().text.ToUpper();
        InputField3.GetComponent<InputField>().text = InputField3.GetComponent<InputField>().text.ToUpper();
        InputField4.GetComponent<InputField>().text = InputField4.GetComponent<InputField>().text.ToUpper();
        InputField5.GetComponent<InputField>().text = InputField5.GetComponent<InputField>().text.ToUpper();
    }

    public void answersChecked()
    {
        //strings to hold each input field string.
        string input1 = InputField1.GetComponent<InputField>().text;
        string input2 = InputField2.GetComponent<InputField>().text;
        string input3 = InputField3.GetComponent<InputField>().text;
        string input4 = InputField4.GetComponent<InputField>().text;
        string input5 = InputField5.GetComponent<InputField>().text;

        //If the input matches the correct answers, the player wins.
        if(input1.Equals("PSYCHE") && input2.Equals("SPACE") && input3.Equals("LAUNCHPAD")
            && input4.Equals("ASTEROID") && input5.Equals("EXPLORE"))
        {
            successMessage = "Great Job!";
            successMessageText.text = successMessage;
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            sceneTransition.GetComponent<SceneTransition>().SceneTransitionOnClick("Journal");
        }
        //If the input is wrong, the player can try again.
        else
        {
            successMessage = "Try Again";
            successMessageText.text = successMessage;
        }

    }
}
