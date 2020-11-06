using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarAnim : MonoBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            animator.SetBool("isActive", true);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            animator.SetBool("isActive", false);
        }
    }
}
