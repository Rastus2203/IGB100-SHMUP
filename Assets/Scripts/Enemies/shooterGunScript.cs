using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterGunScript : MonoBehaviour
{
    GameObject player;

    float lastShotTime;
    float fireRate = 1;

    public GameObject enemyBullet;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        lastShotTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        lookAtPlayer();


        float currentTime = Time.time;
        if (currentTime - lastShotTime > (1 / fireRate))
        {
            lastShotTime = currentTime;
            GameObject bullet = Instantiate(enemyBullet) as GameObject;

            float currentAngle = transform.eulerAngles.z + 90;
            Vector2 currentAngleVect = new Vector2(Mathf.Cos(currentAngle * Mathf.Deg2Rad), Mathf.Sin(currentAngle * Mathf.Deg2Rad));

            bullet.GetComponent<enemyBulletScript>().init(currentAngleVect, transform.position, false);


        }

    }


    void lookAtPlayer()
    {
        Vector3 lookVect = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 0));
        float lookAngle = Mathf.Atan2(lookVect.y, lookVect.x) * Mathf.Rad2Deg - 90;
        transform.Rotate(0, 0, lookAngle, Space.Self);
    }
}
