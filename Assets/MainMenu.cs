using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource themeSong;
    public void Start()
    {
        {
            if (PlayerPrefs.GetFloat("Volume") == 0)
            {
                PlayerPrefs.SetFloat("Volume", .1f);
            }
        }
        volumeSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("Volume"));
        setVolumeSlider();
        volumeSlider.onValueChanged.AddListener(delegate { setVolumeSlider(); });
    }
    public void PlayGame() { 
         PlayerPrefs.SetInt("Level", 1);
         PlayerPrefs.SetInt("TutorialCompleted", 0);
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void setVolumeSlider()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        themeSong.volume = volumeSlider.value;
    }
}
