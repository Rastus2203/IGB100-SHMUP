using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Not sure if there's a better way to pass arguements into a prefab.
    //This method is designed to be called directly after instantiating the prefab as a way of passing arguements.
    public void init()
    {
        Debug.Log("init");
    }
}
