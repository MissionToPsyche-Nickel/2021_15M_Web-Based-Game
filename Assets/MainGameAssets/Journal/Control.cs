using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Control : MonoBehaviour
{
    public int whatScene;
    public Animator animator;

    public void openJournalButtonClicked() {
        //Logic to find player level
        //Will load the appropriate scene
    }
    public void closeJournalButtonClicked() {
        SceneManager.LoadScene("Main");
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
}
