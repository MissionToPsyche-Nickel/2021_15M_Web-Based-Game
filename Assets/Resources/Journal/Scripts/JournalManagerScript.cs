using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalManagerScript : MonoBehaviour
{
    private Text pageOneTitle;
    private Image pageOneImage;
    private Text pageOneText;
    private Text pageTwoTitle;
    private Image pageTwoImage;
    private Text pageTwoText;
    private const int totalPages = 3;
    private int currentPage;
    private Pages pageList;
    public int playerLevel;

    // Start is called before the first frame update
    void Start()
    {
        //load the JSON file
        LoadPages();
        //get player current level
        playerLevel = PlayerPrefs.GetInt("Level");
        //find journal objects
        pageOneTitle = transform.Find("OpenJournal/PageOneTitle").GetComponent<Text>();
        pageOneImage = transform.Find("OpenJournal/ImagePageOne").GetComponent<Image>();
        pageOneText = transform.Find("OpenJournal/TextPageOne").GetComponent<Text>();
        pageTwoTitle = transform.Find("OpenJournal/PageTwoTitle").GetComponent<Text>();
        pageTwoImage = transform.Find("OpenJournal/ImagePageTwo").GetComponent<Image>();
        pageTwoText = transform.Find("OpenJournal/TextPageTwo").GetComponent<Text>();

    }

    private void setCurrentContent()
    {
        if(playerLevel == 0) {
            //set intro page
            
        } 
        else if (playerLevel == 1) {

        }
    }

    private void LoadPages() 
    {
        JournalJsonReader jsonReader = new GameObject().AddComponent<JournalJsonReader>();
            
        jsonReader.jsonFile = Resources.Load("Journal/journal") as TextAsset;

        pageList = jsonReader.LoadPagesFromFile();
    }

    public void NextPagePressed()
    {

    }

    public void PreviousPagePressed()
    {

    }
}
