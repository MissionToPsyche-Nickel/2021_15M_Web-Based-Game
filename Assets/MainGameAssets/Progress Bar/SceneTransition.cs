using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public int whatScene;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(LoadNewScene("Mini-game Test"));
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
        whatScene = setScene(theSceneName);
        animator.SetBool("SceneChange", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(whatScene);
    }

    private int setScene(string sceneName)
    {
        if (sceneName.Equals("Main Menu"))
        {
            return 1;
        }
        else if (sceneName.Equals("Main Gameplay Screen"))
        {
            return 0;
        }
        else if (sceneName.Equals("Sliding Puzzle Game"))
        {
            return 2;
        }
        else if (sceneName.Equals("Memory Match Game"))
        {
            return 3;
        }
        else
        {
            return 0;
        }
    }
}
