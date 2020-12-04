using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
void Pause()
{
    pauseMenuUI.setActive(true);
    Time.timeScale = 1f;
    GameIsPaused = false;
}
void Resume()
{
    pauseMenuUI.setActive(false);
    Time.timeScale = 0f;
    GameIsPaused = true;
}

}