using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roamerGunScript : MonoBehaviour
{
    float lastShot = 0;
    float fireRate = 1;

    public GameObject enemyBullet;

    public float rotOffset = 126;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        float currentTime = Time.time;
        if (currentTime - lastShot > fireRate)
        {
            

            lastShot = currentTime;
            //0, 72, 144, -72, -144
            Vector2[] angles = { 
                new Vector2(Mathf.Cos(Mathf.Deg2Rad * (0 + rotOffset)),    Mathf.Sin(Mathf.Deg2Rad * (0 + rotOffset))),
                new Vector2(Mathf.Cos(Mathf.Deg2Rad * (72 + rotOffset)),   Mathf.Sin(Mathf.Deg2Rad * (72 + rotOffset))),
                new Vector2(Mathf.Cos(Mathf.Deg2Rad * (144 + rotOffset)),  Mathf.Sin(Mathf.Deg2Rad * (144 + rotOffset))), 
                new Vector2(Mathf.Cos(Mathf.Deg2Rad * (-72 + rotOffset)),  Mathf.Sin(Mathf.Deg2Rad * (-72 + rotOffset))), 
                new Vector2(Mathf.Cos(Mathf.Deg2Rad * (-144 + rotOffset)), Mathf.Sin(Mathf.Deg2Rad * (-144 + rotOffset))) 
            };

            for (int i = 0; i < angles.Length; i++)
            {
                GameObject bullet = Instantiate(enemyBullet) as GameObject;
                bullet.GetComponent<enemyBulletScript>().init(angles[i], position, false);
            }
        }
    }
}
