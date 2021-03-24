using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preLaserScript : MonoBehaviour
{
    float spawnTime;
    float waitLength = 1.5f;




    public GameObject bossLaser;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        if (currentTime - spawnTime > waitLength)
        {
            GameObject laser = Instantiate(bossLaser) as GameObject;
            laser.GetComponent<laserScript>().init(transform);


            Destroy(transform.gameObject);
        }
    }

    public void init(Vector3 position, Vector3 rotation) 
    {
        transform.position = position;
        transform.eulerAngles = rotation;
    }
}
