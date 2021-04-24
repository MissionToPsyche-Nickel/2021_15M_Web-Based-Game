using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JournalButtonScript : MonoBehaviour
{
    public Animator animator;

    public void JournalButtonPressed()
    {
        Debug.Log("Journal Button Pressed");
        StartCoroutine(LoadJournal());
        // this'll be what gets hooked into making things appear and disappear to make the journal open up
    }
    private IEnumerator LoadJournal()
    {
        string whatScene = "Journal";
        
        animator.SetBool("SceneChange", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(whatScene);
    }
}
