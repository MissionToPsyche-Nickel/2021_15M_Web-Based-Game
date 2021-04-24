using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Control : MonoBehaviour
{
    public Button exit;
    public Animator animator;
    public void Start()
    {
    }

    /* This is used to go to page one if the player has more journal pages.
     */
    public void goToPageOne() {
        SceneManager.LoadScene("JournalLevel1Page1");
    }

    public void goToPageTwo() {

    }

    public void LoadingAPageWithName(string sceneName) {
        LoadNewScene(sceneName);
    }
    private IEnumerator LoadNewScene(string whatScene)
    {
        animator.SetBool("SceneChange", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(whatScene);
    }
}
