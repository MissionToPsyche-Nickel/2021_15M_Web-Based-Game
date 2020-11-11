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
        if(Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(LoadNewScene());
        }
    }

    public void SceneTransitionOnClick()
    {
        StartCoroutine(LoadNewScene());
    }

    //Loads the new scene and plays the transition for it
    private IEnumerator LoadNewScene()
    {
        animator.SetBool("SceneChange", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(whatScene);
    }
}
