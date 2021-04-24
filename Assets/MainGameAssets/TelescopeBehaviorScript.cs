using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeBehaviorScript : MonoBehaviour
{

    //create objects for the telescope and earth
    public GameObject telescope;
    public Transform earth;

    // Start is called before the first frame update
    void Start()
    {
        //sets the earth as the parent of the telescope
        //the false flag makes the telescope keep its local orientation rather than its orientation in the world
        telescope.transform.SetParent(earth,false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
