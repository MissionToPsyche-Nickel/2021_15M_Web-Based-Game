using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JournalButtonScript : MonoBehaviour
{
    public int playerLevel;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JournalButtonPressed()
    {
        //print("Journal Button Pressed");
        StartCoroutine(LoadNewScene(playerLevel));
        // this'll be what gets hooked into making things appear and disappear to make the journal open up
    }
    private IEnumerator LoadNewScene(int playerLevel)
    {
        playerLevel = PlayerPrefs.GetInt("Level");
        string whatScene = "Title";
        if (playerLevel == 1)
        {
            whatScene = "JournalLevel1Page1";
        }
        else if (playerLevel == 2)
        {
            whatScene = "JournalLevel2Page1";
        }
        else if (playerLevel == 3)
        {
            whatScene = "JournalLevel3Page2";
        }
        animator.SetBool("SceneChange", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(whatScene);
    }
}
