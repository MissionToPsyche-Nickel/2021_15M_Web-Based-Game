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
    {    
        ResetGameProgress();
        SceneManager.LoadScene("Main");
        Debug.Log("Main Menu Clicked...");

    }

    public void ExitClick()
    {    
        ResetGameProgress();
        SceneManager.LoadScene("Title");
        Debug.Log("Exit Clicked...");

    }

    private void ResetGameProgress()
    {
        PlayerPrefs.SetInt("Level", 1);
        
        // Reset Tutorial state
        PlayerPrefs.SetInt("TutorialCompleted", 0);
        PlayerPrefs.SetInt("TutorialStep", 0);

        // Reset all level dialog steps
        for (int i = 2; i <= 5; i++)
        {
            PlayerPrefs.SetInt("Level" + i + "DialogStep", 0);
        }

        // Crucial for WebGL: Force save to the browser's IndexedDB
        PlayerPrefs.Save();
    }

}