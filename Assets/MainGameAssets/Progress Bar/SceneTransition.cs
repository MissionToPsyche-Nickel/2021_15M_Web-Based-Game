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

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Loads the new scene and plays the transition for it
    public IEnumerator LoadNewScene(string sceneName)
    {
        string theSceneName = sceneName;
        animator.SetBool("SceneChange", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
