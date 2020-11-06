using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarAnim : MonoBehaviour
{

    public Animator animator;
    private bool colliding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(colliding == true)
        {
            animator.SetBool("isActive", true);
        }
        if (colliding == false)
        {
            animator.SetBool("isActive", false);
        }
    }

    // Starts playing the progress bar animation when the scan bar collides with an object.
    void OnCollisionEnter(Collision collision)
    {
        colliding = true;
    }

    //Reset the progress bar animation when the scan bar stops colliding with an object.
    void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }
}
