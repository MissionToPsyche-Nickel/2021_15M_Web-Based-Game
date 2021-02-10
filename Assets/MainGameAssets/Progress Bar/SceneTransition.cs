using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    // add to this array to add your minigame to the rotation
    private static readonly string[] minigames =
    {
        "MemoryGame",
        "Sliding Puzzle"
    };

    public string whatScene;
    public Animator sceneTransition;
    public Slider progressBar;

    // Start is called before the first frame update
    void Start()
    {
        if (progressBar)
        {
            progressBar.onValueChanged.AddListener(delegate { progressBarValueChange(); });
        }
        sceneTransition.SetBool("SceneChange", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void progressBarValueChange()
    {
        if (progressBar.value == 1)
        {
            StartCoroutine(LoadNewScene(minigames[Random.Range(0, minigames.Length)]));
        }
    }

    public void SceneTransitionOnClick()
    {
        StartCoroutine(LoadNewScene(whatScene));
    }

    //Loads the new scene and plays the transition for it
    public IEnumerator LoadNewScene(string sceneName)
    {
        sceneTransition.SetBool("SceneChange", true);
        string theSceneName = sceneName;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(theSceneName);
    }
}
