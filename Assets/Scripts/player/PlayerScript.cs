using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Vector2 currentSpeed = new Vector2(0, 0);
    public float maxSpeed = 0.18f;
    public float acceleration = 0.1f;
    public float deceleration = 0.08f;

    public int collisions;

    float immunityLength;
    float lastImmunity;

    float minX;
    float maxX;
    float minY;
    float maxY;

    public float health = 100;


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
    }

    // Update is called once per frame
    void Update()
    {
        doMovement();
        checkBoundaryCollision();

    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        float currentTime = Time.time;

        if (currentTime - lastImmunity > immunityLength)
        {
            lastImmunity = currentTime;
            GameObject otherParent = other.gameObject;
            otherScript = otherParent.
        }


        Debug.Log("hit");
    }*/

    void damageCollider(float damage)
    {
        float currentTime = Time.time;

        if (currentTime - lastImmunity > immunityLength)
        {
            lastImmunity = currentTime;
            health -= damage;
        }


        Debug.Log("hit");
    }

    //If player has moved outside the bounds of the screen, set their speed in that direction to 0 and move them back to the border.
    void checkBoundaryCollision()
    {
        //Google tells me I get marginally better performance if I store the position in temporary variables instead of reading transform.position multiple times.
        //Can't imagine it will matter but why not?
        Vector3 position = transform.position;
        float x = position.x;
        float y = position.y;
        float z = position.z;


        if (x > maxX)
        {
            transform.position = (new Vector3(maxX, y, z));
            currentSpeed[0] = 0;
        }

        if (x < minX)
        {
            transform.position = (new Vector3(minX, y, z));
            currentSpeed[0] = 0;
        }
            
        if (y > maxY)
        {
            transform.position = (new Vector3(x, maxY, z));
            currentSpeed[1] = 0;
        }

        if (y < minY)
        {
            transform.position = (new Vector3(x, minY, z));
            currentSpeed[1] = 0;
        }
    }


    void doMovement()
    {

        //Checks if any movement keys are currently pressed, then changes currentSpeed based on keypress.
        //Also makes sure the player doesn't go over their max speed.
        if (Input.GetKey("w"))
        {
            currentSpeed[1] += acceleration * Time.deltaTime;
            if (currentSpeed[1] > maxSpeed) currentSpeed[1] = maxSpeed;
        }
        if (Input.GetKey("a"))
        {
            currentSpeed[0] -= acceleration * Time.deltaTime;
            if (currentSpeed[0] < -maxSpeed) currentSpeed[0] = -maxSpeed;
        }
        if (Input.GetKey("s"))
        {
            currentSpeed[1] -= acceleration * Time.deltaTime;
            if (currentSpeed[1] < -maxSpeed) currentSpeed[1] = -maxSpeed;
        }
        if (Input.GetKey("d"))
        {
            currentSpeed[0] += acceleration * Time.deltaTime;
            if (currentSpeed[0] > maxSpeed) currentSpeed[0] = maxSpeed;
        }

        //Player is constantly slowing down. Friction???
        if (currentSpeed[0] > 0) currentSpeed[0] -= deceleration * Time.deltaTime;
        if (currentSpeed[0] < 0) currentSpeed[0] += deceleration * Time.deltaTime;
        if (currentSpeed[1] > 0) currentSpeed[1] -= deceleration * Time.deltaTime;
        if (currentSpeed[1] < 0) currentSpeed[1] += deceleration * Time.deltaTime;

        //Moves the player
        //transform.Translate(currentSpeed);
        transform.position = transform.position + new Vector3(currentSpeed.x, currentSpeed.y, 0);
    }


}