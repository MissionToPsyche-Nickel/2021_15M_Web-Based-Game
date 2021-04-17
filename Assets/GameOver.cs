using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{    /*   public void setup(int state)
    {

    }*/
    // Start is called before the first frame update
  /*  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    public void RestartClick()
    {    PlayerPrefs.SetInt("Level", 1);
         PlayerPrefs.SetInt("TutorialCompleted", 0);
        SceneManager.LoadScene("Main");
        Debug.Log("Main Menu Clicked...");

    }

    public void ExitClick()
    {    PlayerPrefs.SetInt("Level", 1);
         PlayerPrefs.SetInt("TutorialCompleted", 0);
        SceneManager.LoadScene("Title");
        Debug.Log("Exit Clicked...");

    }

}