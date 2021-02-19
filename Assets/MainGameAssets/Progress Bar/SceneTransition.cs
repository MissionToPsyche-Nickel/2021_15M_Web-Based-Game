using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public string whatScene;
    public Animator sceneTransition;
    public Slider progressBar;


    // Start is called before the first frame update
    void Start()
    {
        progressBar.onValueChanged.AddListener(delegate { progressBarValueChange(); });
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
            StartCoroutine(LoadNewScene("MemoryGame"));
        }
    }

    public void SceneTransitionOnClick()
    {
        StartCoroutine(LoadNewScene(whatScene));
    }

    //Loads the new scene and plays the transition for it
    private IEnumerator LoadNewScene(string sceneName)
    {
        sceneTransition.SetBool("SceneChange", true);
        string theSceneName = sceneName;
        sceneTransition.SetBool("SceneChange", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(theSceneName);
    }
}
