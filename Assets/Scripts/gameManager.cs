using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public int currentWave = 0;
    public int waveState = 0;
    public List<Action> waves = new List<Action>();

    // Start is called before the first frame update
    void Start()
    {
        waves.Add(() => wave1());
        waves.Add(() => wave2());
        waves.Add(() => wave3());


        currentWave = UnityEngine.Random.Range(0, waves.Count);
        waves[currentWave]();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void wave1()
    {
        Debug.Log("1");
    }

    void wave2()
    {
        Debug.Log("2");
    }

    void wave3()
    {
        Debug.Log("3");
    }


}
