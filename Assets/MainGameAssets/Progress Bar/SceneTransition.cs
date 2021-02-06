using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string whatScene;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        whatScene = "Title";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(LoadNewScene(whatScene));
        }
    }

    public void SceneTransitionOnClick()
    {
        StartCoroutine(LoadNewScene(whatScene));
    }

    //Loads the new scene and plays the transition for it
    private IEnumerator LoadNewScene(string sceneName)
    {
        string theSceneName = sceneName;
        animator.SetBool("SceneChange", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(theSceneName);
    }
}
