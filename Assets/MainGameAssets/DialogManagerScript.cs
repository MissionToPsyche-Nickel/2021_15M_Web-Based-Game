using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManagerScript : MonoBehaviour
{
    private Queue<DialogSnippet> dialogQueue = new Queue<DialogSnippet>();
    private DialogSnippet activeSnippet = null;

    private Image portraitImage;
    private Text titleTextbox;
    private Text textTextbox;

    private Transform[] visibilityList;

    // Start is called before the first frame update
    void Start()
    {
        /*Logical check to ensure the tutorial only displays the first time the user is on the main scene */
        if (!PlayerPrefs.HasKey("hasTutorialDisplayed")) {
            portraitImage = transform.Find("Portrait").GetComponent<Image>();
            titleTextbox = transform.Find("DialogBackground/Title").GetComponent<Text>();
            textTextbox = transform.Find("DialogBackground/Text").GetComponent<Text>();

            visibilityList = gameObject.GetComponentsInChildren<Transform>();

            AddDialog(null, "Tutorial Man", "Welcome to the game!\nI am Tutorial Man, and I will be guiding you through how to play.\nPress the arrow button to continue.");
            AddDialog(null, "Tutorial Man", "Your goal is to complete your journal of celestial objects by identifying them with your telescope.\nYou can open your journal with the button at the bottom left.");
            AddDialog(null, "Tutorial Man", "The telescope is how you identify celestial objects.\nYou can control it using the up and down arrow keys, or W and S.");
            AddDialog(null, "Tutorial Man", "Be sure to stay focused on the object for a few seconds while the progress bar fills up, otherwise you won't get a good look at it.");
            AddDialog(null, "Tutorial Man", "After you scan the object, you will be sent to a minigame.\nGood luck, and happy astronomy!");
        } 
    }

    // Update is called once per frame
    void Update()
    {
        //Needed to keep an empty dialog box from being built
        if (PlayerPrefs.HasKey("hasTutorialDisplayed")) {
            Destroy(gameObject);
        }
    }

    public void UpdateDialog()
    {
        if (activeSnippet == null && dialogQueue.Count == 0)
        {
            foreach (Transform t in visibilityList)
            {
                t.localScale = new Vector3(0, 0, 0);
                PlayerPrefs.SetInt("hasTutorialDisplayed", 1);
            }
            return;
        }
        else if (activeSnippet == null) // implies dialog queue is not empty
        {
            activeSnippet = dialogQueue.Dequeue();

            portraitImage.sprite = activeSnippet.portrait;
            titleTextbox.text = activeSnippet.title;
            textTextbox.text = activeSnippet.text;

            foreach (Transform t in visibilityList)
            {
                t.localScale = new Vector3(1, 1, 1);
            }
        }

    }

    public void NextDialogPressed()
    {
        activeSnippet = null;
        UpdateDialog();
    }

    public void AddDialog(Sprite portrait, string title, string text)
    {
        dialogQueue.Enqueue(new DialogSnippet(portrait, title, text));
        UpdateDialog();
    }

    public void AddDialog(Sprite portrait, string title, IEnumerable<string> textList)
    {
        foreach (string text in textList)
        {
            dialogQueue.Enqueue(new DialogSnippet(portrait, title, text));
        }
        UpdateDialog();
    }

    // this is for testing, should be deleted at some point
    private static int testNumber = 1;
    public void TestButtonPressed()
    {
        AddDialog(null, "Null Man", "That's number " + testNumber);
        testNumber++;
    }
}

public class DialogSnippet
{
    public Sprite portrait;
    public string title;
    public string text;

    public DialogSnippet(Sprite portrait, string title, string text)
    {
        this.portrait = portrait;
        this.title = title;
        this.text = text;
    }

    //Not sure if these will work, for now need to clear playerPrefs manually
    public void OnApplicationQuit() {
        PlayerPrefs.DeleteAll();
    }

    public void OnApplicationStart() {
        PlayerPrefs.DeleteAll();
    }
}
