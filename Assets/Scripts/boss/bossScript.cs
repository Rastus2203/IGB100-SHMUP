using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossScript : MonoBehaviour
{
    public float health = 100;
    public float currentHealth = 400;
    float maxHealth = 400;

    float minX;
    float maxX;
    float minY;
    float maxY;

    float laserSpawnRate = 0.3f;
    float lastLaser = 0;

    GameObject manager;
    public GameObject bossPreLaser;

    // Start is called before the first frame update
    void Start()
    {


        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));


        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;


        manager = GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        health = currentHealth / maxHealth * 100;

        checkDead();
        doLaser();
    }

    void doLaser()
    {
        float currentTime = Time.time;
        if (currentTime - laserSpawnRate > lastLaser)
        {
            lastLaser = currentTime;
            GameObject preLaser = Instantiate(bossPreLaser) as GameObject;

            float x = UnityEngine.Random.Range(minX, maxX);
            float y = UnityEngine.Random.Range(minY, maxY);

            float angle = UnityEngine.Random.Range(0, 360);



            preLaser.GetComponent<preLaserScript>().init(new Vector3(x, y, 0), new Vector3(0, 0, angle));
        }
    }



    void damageCollider(float damage)
    {
        currentHealth -= damage;
    }


    void checkDead()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("winScene");
            Destroy(transform.parent.gameObject);
            manager.GetComponent<gameManager>().destroyed();


        }
    }
}
