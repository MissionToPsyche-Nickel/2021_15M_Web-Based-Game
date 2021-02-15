using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
        
    

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Escape))
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    }
    // click action event on pause button
void Pause()
{
    pauseMenuUI.SetActive(true);
    Time.timeScale = 1f;
    GameIsPaused = false;

}
    //resume button click action event
void Resume()
{
    pauseMenuUI.SetActive(false);
    Time.timeScale = 0f;
    GameIsPaused = true;
}
    //clcik action on menu button to return to main menu
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    //click action event on quit game
    public void QuitGame()
    {
        Debug.Log("Quiting Game....");
        Application.Quit();
    }

}