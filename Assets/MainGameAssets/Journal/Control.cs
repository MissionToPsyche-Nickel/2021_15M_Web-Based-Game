using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Control : MonoBehaviour
{
    public Animator animator;
    public void Start()
    {

    }
    public void openJournalButtonClicked() {
        //Logic to find player level
        //Will load the appropriate scene
    }
    public void closeJournalButtonClicked() {
        SceneManager.LoadScene(0);
    }

    /* This is used to go to page one if the player has more journal pages.
     */
    public void goToPageOne() {
        SceneManager.LoadScene("JournalDefaultPage1");
    }

    public void goToPageTwo() {

    }

    public void LoadingAPageWithName(string sceneName) {
        SceneManager.LoadScene("sceneName");
    }
    private IEnumerator LoadNewScene(string whatScene)
    {
        animator.SetBool("SceneChange", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(whatScene);
    }
}
