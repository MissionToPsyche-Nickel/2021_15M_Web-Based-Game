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
    private int tutorialStep = 0;

    private Transform[] visibilityList;

    // Start is called before the first frame update
    void Start()
    {
        /*Logical check to ensure the tutorial only displays the first time the user is on the main scene */
        //portraitImage = transform.Find("Portrait").GetComponent<Image>();
        titleTextbox = transform.Find("DialogBackground/Title").GetComponent<Text>();
        textTextbox = transform.Find("DialogBackground/Text").GetComponent<Text>();

        visibilityList = gameObject.GetComponentsInChildren<Transform>();

        if (PlayerPrefs.GetInt("TutorialCompleted") == 0)
        {
            tutorialStep = PlayerPrefs.GetInt("TutorialStep", 0);

            if (tutorialStep <= 0)
                AddDialog("Psyche", "Welcome to the game!\nMy name is Psyche, and I'm a scientist with a particular interest in space. I will be guiding you through how to play.\nPress the arrow button to continue.");

            if (tutorialStep <= 1)
                AddDialog("Psyche", "Your goal is to complete your journal by identifying celestial objects with your telescope. You can open your journal using the button at the bottom left.");

            if (tutorialStep <= 2)
                AddDialog("Psyche", "The telescope is how you identify celestial objects.\nYou can control it using the up and down arrow keys, or W and S.");

            if (tutorialStep <= 3)
                AddDialog("Psyche", "Be sure to stay focused on the object for a few seconds while the progress bar fills up. Otherwise, you won’t get a good look at it.");

            if (tutorialStep <= 4)
                AddDialog("Psyche", "After you scan the object, you will be sent to a minigame.\nGood luck, and happy astronomy!");
    
        }
        UpdateDialog();

        if (PlayerPrefs.GetInt("Level") == 2)
        {
            string levelKey = "Level2DialogStep";
            int levelStep = PlayerPrefs.GetInt(levelKey, 0);
            if(levelStep <= 0)
            AddDialog(
            "Psyche",
            "Now that you’ve learned how to use your telescope, the world—or… the universe—is your oyster! " +
            "See what else you can find. " +
            "Remember, find and focus on the distant twinkle to fill the progress bar."
        );
        }
        UpdateDialog();

        if (PlayerPrefs.GetInt("Level") == 3)
        {
            string levelKey = "Level3DialogStep";
            int levelStep = PlayerPrefs.GetInt(levelKey, 0);
            if(levelStep <= 0)
            AddDialog("Psyche", "What other planets can you find?");
        }

        UpdateDialog();

        if (PlayerPrefs.GetInt("Level") == 4)
        {
            string levelKey = "Level4DialogStep";
            int levelStep = PlayerPrefs.GetInt(levelKey, 0);
            if(levelStep <= 0)
            AddDialog(
            "Psyche",
            "Now that you’ve learned about a few planets in our solar system, let’s focus on finding some new galaxies. " +
            "Galaxies are huge clusters of solar systems, stars, and gases. " +
            "The galaxy that we are in is called the Milky Way galaxy."
        );
        }


        UpdateDialog();

        if (PlayerPrefs.GetInt("Level") == 5)
        {
            string levelKey = "Level5DialogStep";
            int levelStep = PlayerPrefs.GetInt(levelKey, 0);
            if(levelStep <= 0)
            AddDialog(
                "Psyche",
                "The last thing I want to show you before you go is an asteroid named after the Greek goddess Psyche. " +
                "That name should sound familiar, since I was named after this asteroid!"
            );
            if(levelStep <= 1)
            AddDialog(
                "Psyche",
                "Why is this asteroid important? Well, it’s one of a kind, and we stand to learn a lot about it by studying it. " +
                "In fact, NASA has taken a special interest in Psyche and is planning an expedition to study it in space! " +
                "There’s a lot more to learn, but you’ll have to complete the minigame to find out."
            );
            if(levelStep <= 2)
            AddDialog(
                "Psyche",
                "By the way, Psyche is so far away that you won’t be able to see it through that Hobby Telescope of yours. " +
                "Instead, we’ll use the Very Large Telescope located in Chile. Give it a go!"
            );    
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateDialog()
    {
        if (activeSnippet == null && dialogQueue.Count == 0)
        {
            foreach (Transform t in visibilityList)
            {
                t.localScale = new Vector3(0, 0, 0);
            }
            return;
        }
        else if (activeSnippet == null) // implies dialog queue is not empty
        {
            activeSnippet = dialogQueue.Dequeue();

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

        tutorialStep++;
        PlayerPrefs.SetInt("TutorialStep", tutorialStep);
        

        if (dialogQueue.Count == 0)
        {
            PlayerPrefs.SetInt("TutorialCompleted", 1);
        }

        //level logic
        int currentLevel = PlayerPrefs.GetInt("Level");
        if(currentLevel>=2 && currentLevel <= 5)
        {
            string levelKey = "Level" + currentLevel + "DialogStep";

            int levelStep = PlayerPrefs.GetInt(levelKey, 0);
            levelStep++;
            PlayerPrefs.SetInt(levelKey, levelStep);
        }

        UpdateDialog();
    }

    public void AddDialog(string title, string text)
    {
        dialogQueue.Enqueue(new DialogSnippet(title, text));
        UpdateDialog();
    }

    public void AddDialog(string title, IEnumerable<string> textList)
    {
        foreach (string text in textList)
        {
            dialogQueue.Enqueue(new DialogSnippet(title, text));
        }
        UpdateDialog();
    }

    // this is for testing, should be deleted at some point
    private static int testNumber = 1;
    public void TestButtonPressed()
    {
        AddDialog("Null Man", "That's number " + testNumber);
        testNumber++;
    }
}

public class DialogSnippet
{
    public string title;
    public string text;

    public DialogSnippet(string title, string text)
    {
        this.title = title;
        this.text = text;
    }
}
