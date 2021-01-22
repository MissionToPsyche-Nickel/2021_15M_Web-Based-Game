using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JournalButtonScript : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JournalButtonPressed()
    {
        //print("Journal Button Pressed");
        StartCoroutine(LoadNewScene(Gamestate.instance.gameProgress));
        // this'll be what gets hooked into making things appear and disappear to make the journal open up
    }
    private IEnumerator LoadNewScene(int playerLevel)
    {
        int whatScene = 0;
        if(playerLevel == 0)
        {
            whatScene = 7;
        }
        animator.SetBool("SceneChange", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(whatScene);
    }
}
