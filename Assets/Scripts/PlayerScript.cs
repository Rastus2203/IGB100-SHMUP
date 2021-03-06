using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Vector2 currentSpeed = new Vector2(0, 0);
    public float maxSpeed = 0.04f;
    public float acceleration = 0.15f;
    public float deceleration = 0.03f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        doMovement();

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


        if (currentSpeed[0] > 0) currentSpeed[0] -= deceleration * Time.deltaTime;
        if (currentSpeed[0] < 0) currentSpeed[0] += deceleration * Time.deltaTime;
        if (currentSpeed[1] > 0) currentSpeed[1] -= deceleration * Time.deltaTime;
        if (currentSpeed[1] < 0) currentSpeed[1] += deceleration * Time.deltaTime;


        transform.Translate(currentSpeed);
    }
}
