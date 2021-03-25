using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    int currentWave = 0;
    int waveState = 0;
    bool waveInit = false;
    bool waveInProgress = false;
    int deathCount;
    int maxLength;
    int deathsToContinue;
    float waveStartTime;

    List<Action> waves = new List<Action>();

    public GameObject ShooterParent;
    public GameObject ChaserParent;
    public GameObject bossParent;
    public GameObject roamerParent;

    // Start is called before the first frame update
    void Start()
    {
        waves.Add(() => wave1());
        waves.Add(() => wave2());
        waves.Add(() => wave3());




    }

    // Update is called once per frame
    void Update()
    {
        if (!waveInProgress)
        {
            currentWave = UnityEngine.Random.Range(0, waves.Count);
            currentWave = 0;
        }

        waves[currentWave]();

    }

    public void destroyed()
    {
        deathCount++;
        Debug.Log("dead");
    }

    void wave1()
    {
        Debug.Log("1");

        if (waveState == 0)
        {
            if (!waveInit)
            {
                waveStartTime = Time.time;
                maxLength = 20;
                deathsToContinue = 3;
                waveInit = true;

                spawnShooter(new Vector3(11, 7, 0));
                spawnShooter(new Vector3(11, 0, 0));
                spawnShooter(new Vector3(11, -7, 0));
                spawnShooter(new Vector3(-11, 7, 0));
                spawnShooter(new Vector3(-11, 0, 0));
                spawnShooter(new Vector3(-11, -7, 0));
            }


            if ((Time.time - waveStartTime > maxLength) || (deathCount >= deathsToContinue))
            {
                waveState = 1;
                waveInit = false;
            }
        } else if (waveState == 1)
        {
            if (!waveInit)
            {
                waveStartTime = Time.time;
                maxLength = 5;
                deathsToContinue = 8;
                waveInit = true;

                spawnChaser(new Vector3(0, 5, 0));
                spawnChaser(new Vector3(-5.5f, 4.5f, 0));
                spawnChaser(new Vector3(5.5f, 4.5f, 0));
                spawnChaser(new Vector3(-6.5f, -7, 0));
                spawnChaser(new Vector3(6.5f, -7, 0));


            }
            if ((Time.time - waveStartTime > maxLength) || (deathCount >= deathsToContinue))
            {
                waveState = 2;
                waveInit = false;
            }
        } else if (waveState == 2)
        {
            if (!waveInit)
            {
                waveStartTime = Time.time;
                maxLength = 999;
                deathsToContinue = 18;
                waveInit = true;

                spawnChaser(new Vector3(0, 5, 0));
                spawnChaser(new Vector3(-5.5f, 4.5f, 0));
                spawnChaser(new Vector3(5.5f, 4.5f, 0));
                spawnChaser(new Vector3(-6.5f, -7, 0));
                spawnChaser(new Vector3(6.5f, -7, 0));

                spawnRoamer(new Vector3(15, 0, 0));
                spawnRoamer(new Vector3(-15, 0, 0));


            }
            if ((Time.time - waveStartTime > maxLength) || (deathCount >= deathsToContinue))
            {
                waveState = 3;
                waveInit = false;
            }
        } else if (waveState == 3)
        {
            if (!waveInit)
            {
                waveStartTime = Time.time;
                maxLength = 999;
                deathsToContinue = 999;
                waveInit = true;

                spawnBoss();
            }
        }
    }

    void wave2()
    {
        Debug.Log("2");
    }

    void wave3()
    {
        Debug.Log("3");
    }


    void spawnShooter(Vector3 position)
    {
        GameObject temp = Instantiate(ShooterParent).transform.GetChild(0).gameObject as GameObject;

        temp.GetComponent<shooterScript>().init(position);
    }


    void spawnChaser(Vector3 position)
    {
        GameObject temp = Instantiate(ChaserParent).transform.GetChild(0).gameObject as GameObject;

        temp.GetComponent<ChaserScript>().init(position);
    }

    void spawnRoamer(Vector3 position)
    {
        GameObject temp = Instantiate(roamerParent).transform.GetChild(0).gameObject as GameObject;

        temp.GetComponent<roamerScript>().init(position);
    }

    void spawnBoss()
    {
        Debug.Log("boss");
        GameObject temp = Instantiate(bossParent).transform.GetChild(0).gameObject as GameObject;
    }


}
