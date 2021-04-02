using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


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
    private int playerLevel;
    private GameObject sceneTransition;
    public GameObject journal;

    // Start is called before the first frame update
    void Start()
    {
        //load the JSON file
        LoadPages();
        //get player current level -- starts at 1
        playerLevel = PlayerPrefs.GetInt("Level");
        
        sceneTransition = GameObject.Find("SceneTransitionHolder");
        //find journal objects
        pageOneTitle = transform.Find("PageOneTitle").GetComponent<Text>();
        pageOneImage = transform.Find("ImagePageOne").GetComponent<Image>();
        pageOneText = transform.Find("TextPageOne").GetComponent<Text>();
        pageTwoTitle = transform.Find("PageTwoTitle").GetComponent<Text>();
        pageTwoImage = transform.Find("ImagePageTwo").GetComponent<Image>();
        pageTwoText = transform.Find("TextPageTwo").GetComponent<Text>();

        setCurrentContent();
    }

/* The journal should open to the newest page. */
    private void setCurrentContent()
    {
        switch (playerLevel)
        {
            case 1:
                setPageOne();
                break;
            
            case 2:
                setPageOne();
                break;

            case 3:
                setPageOne();
                break;

            case 4:
                setPageTwo();
                break;

            case 5:
                setPageTwo();
                break;

            case 6:
                setPageThree();
                break;

            default:
                setPageOne();
                break;
        }
    }

    private void setPageOne()
    {
        if (playerLevel < 2) {
            //set intro page
            pageOneTitle.text = pageList.pages[0].title;
            pageOneImage.sprite = Resources.Load<Sprite>(pageList.pages[0].image);
            pageOneText.text = pageList.pages[0].text;
            pageTwoTitle.text = "";
            pageTwoImage.sprite = null;
            pageTwoText.text = "";
            
            currentPage = 1;

        } else if (playerLevel == 2) {
            pageOneTitle.text = pageList.pages[1].title;
            pageOneImage.sprite = Resources.Load<Sprite>(pageList.pages[1].image);
            pageOneText.text = pageList.pages[1].text;
            pageTwoTitle.text = "";
            pageTwoImage.sprite = null;
            pageTwoText.text = "";
            
            currentPage = 1;

        } else {
            pageOneTitle.text = pageList.pages[1].title;
            pageOneImage.sprite = Resources.Load<Sprite>(pageList.pages[1].image);
            pageOneText.text = pageList.pages[1].text;
            pageTwoTitle.text = pageList.pages[2].title;
            pageTwoImage.sprite = Resources.Load<Sprite>(pageList.pages[2].image);
            pageTwoText.text = pageList.pages[2].text;
            
            currentPage = 1;
        }
    }

    private void setPageTwo()
    {
        if(playerLevel < 4) //no content on these pages
        {
            pageOneTitle.text = "";
            pageOneImage.sprite = null;
            pageOneText.text = "";
            pageTwoTitle.text = "";
            pageTwoImage.sprite = null;
            pageTwoText.text = "";
            
            currentPage = 2;
        }
        else if (playerLevel == 4)
        {
            pageOneTitle.text = pageList.pages[3].title;
            pageOneImage.sprite = Resources.Load<Sprite>(pageList.pages[3].image);
            pageOneText.text = pageList.pages[3].text;
            pageTwoTitle.text = "";
            pageTwoImage.sprite = null;
            pageTwoText.text = "";
            
            currentPage = 2;
        }
        else
        {
            pageOneTitle.text = pageList.pages[3].title;
            pageOneImage.sprite = Resources.Load<Sprite>(pageList.pages[3].image);
            pageOneText.text = pageList.pages[3].text;
            pageTwoTitle.text = pageList.pages[4].title;
            pageTwoImage.sprite = Resources.Load<Sprite>(pageList.pages[4].image);
            pageTwoText.text = pageList.pages[4].text;
            
            currentPage = 2;
        }
    }

    private void setPageThree() 
    {
        if (playerLevel > 5)
        {
            pageOneTitle.text = pageList.pages[5].title;
            pageOneImage.sprite = Resources.Load<Sprite>(pageList.pages[5].image);
            pageOneText.text = pageList.pages[5].text;
            pageTwoTitle.text = "";
            pageTwoImage.sprite = null;
            pageTwoText.text = "";
            
            currentPage = 3;
        }
        else
        {
            pageOneTitle.text = "";
            pageOneImage.sprite = null;
            pageOneText.text = "";
            pageTwoTitle.text = "";
            pageTwoImage.sprite = null;
            pageTwoText.text = "";
            
            currentPage = 3;
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
        switch (currentPage)
        {
            case 1:
                setPageTwo();
                break;

            case 2:
                setPageThree();
                break;

            default:    //do nothing
                break;
        }
    }

    public void PreviousPagePressed()
    {
        switch (currentPage)
        {
            case 2:
                setPageOne();
                break;

            case 3:
                setPageTwo();
                break;

            default:    //do nothing
                break;
        }
    }

    public void closeButtonPressed()
    {
        if (playerLevel > 5) {
            //sceneTransition.GetComponent<SceneTransition>().SceneTransitionOnClick("Main");
            journal.SetActive(false);
        }
        else {
            /* sceneTransition.GetComponent<SceneTransition>().SceneTransitionOnClick("Main");*/
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // return to previous scene

        }
    }

}
