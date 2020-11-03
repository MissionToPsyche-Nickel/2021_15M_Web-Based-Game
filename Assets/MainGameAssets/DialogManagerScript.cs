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
        portraitImage = transform.Find("Portrait").GetComponent<Image>();
        titleTextbox = transform.Find("DialogBackground/Title").GetComponent<Text>();
        textTextbox = transform.Find("DialogBackground/Text").GetComponent<Text>();

        visibilityList = gameObject.GetComponentsInChildren<Transform>();

        AddDialog(null, "Null Man", "test");
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
        }

        portraitImage.sprite = activeSnippet.portrait;
        titleTextbox.text = activeSnippet.title;
        textTextbox.text = activeSnippet.text;

        gameObject.SetActive(true);
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
}
