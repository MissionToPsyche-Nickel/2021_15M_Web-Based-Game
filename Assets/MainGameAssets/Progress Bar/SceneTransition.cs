using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public string whatScene;
    public Animator animator;
    public Slider progressBar;

    // Start is called before the first frame update
    void Start()
    {
        progressBar.onValueChanged.AddListener(delegate { progressBarValueChange(); });
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
        StartCoroutine(LoadNewScene("Mini-game Test"));
    }

    //Loads the new scene and plays the transition for it
    private IEnumerator LoadNewScene(string sceneName)
    {
        string theSceneName = sceneName;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(theSceneName);
    }
    }
