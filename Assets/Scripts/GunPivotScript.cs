using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPivotScript : MonoBehaviour
{
    public Vector2 mouseDelta;
    public float rotationAngle;
    float lastShotTime;
    float fireRate;

    public GameObject playerBullet;

    // Start is called before the first frame update
    void Start()
    {
        lastShotTime = Time.time;
        fireRate = 1;
    }

    // Update is called once per frame
    void Update()
    {
        rotateToMouse();

        if (Input.GetMouseButton(0))
        {
            shoot();
        }

    }

    void shoot()
    {
        float currentTime = Time.time;

        if ((currentTime - lastShotTime) > (1 / fireRate))
        {
            lastShotTime = currentTime;
            Debug.Log("shoot");

            GameObject bullet = Instantiate(playerBullet) as GameObject;
            //Debug.Log(typeof(bullet));
            Debug.Log(bullet);
            bullet.GetComponent<BulletScript>().init();
            //BulletScript playerBulletObj = bullet.GetComponent<BulletScript>();
            //bullet.init();

        }
        

    }

    //Rotates the player to face the current mouse position.
    void rotateToMouse()
    {
        //Gets the mouse position relative to the player to store in mouseDelta
        Vector3 mousePosition3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosition2 = new Vector2(mousePosition3.x, mousePosition3.y);
        Vector2 currentPosition = transform.position;
        mouseDelta = mousePosition2 - currentPosition;

        //Reset the viewing angle. transform.Rotate rotates relative to the current angle so this is necessary.
        //There is almost definitely a better way to do the rotation, but this works.
        transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 0)); 

        //Gets the angle between the player and the mouse, then rotates.
        rotationAngle = Mathf.Atan2(mouseDelta.y, mouseDelta.x) * Mathf.Rad2Deg - 90;
        transform.Rotate(0, 0, rotationAngle, Space.Self);

    }
}
