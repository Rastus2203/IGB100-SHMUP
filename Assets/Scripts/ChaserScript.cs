using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserScript : MonoBehaviour
{
    float minX;
    float maxX;
    float minY;
    float maxY;



    GameObject player;
    Vector3 lookVect;
    public float lookAngle;
    public float speed = 1;
    public float rotateScalar = 20;
    public float distanceScalar = 10;
    public float a;

    public float angleDelta;

    Rigidbody objRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        objRigidBody = GetComponent<Rigidbody>();


        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));


        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;






        player = GameObject.FindWithTag("Player");


        lookVect = player.transform.position - transform.position;

        transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 0));
        lookAngle = Mathf.Atan2(lookVect.y, lookVect.x) * Mathf.Rad2Deg - 90;
        transform.Rotate(0, 0, lookAngle, Space.Self);

    }

    // Update is called once per frame
    void Update()
    {
        turnToPlayer();

        //Current direction of this object
        float currentAngle = transform.eulerAngles.z + 90;
        //Vector pointing in direction object is facing
        Vector2 currentAngleVect = new Vector2(Mathf.Cos(currentAngle * Mathf.Deg2Rad), Mathf.Sin(currentAngle * Mathf.Deg2Rad));
        currentAngleVect = (currentAngleVect / currentAngleVect.magnitude) * Time.deltaTime * speed;

        Vector3 currentPos = transform.position;
        float currentX = currentPos.x;
        float currentY = currentPos.y;
        float currentZ = currentPos.z;

        transform.position = new Vector3(currentX + currentAngleVect.x, currentY + currentAngleVect.y, currentZ);


    }


    void turnToPlayer()
    {
        //Slowly rotate object to face the player

        float distance = (30 - Vector3.Distance(transform.position, player.transform.position)) * distanceScalar;
        a = distance;

        //Current direction of this object
        float currentAngle = transform.eulerAngles.z;

        //Vector containing difference between the position of the player and this object
        lookVect = player.transform.position - transform.position;

        //Vector pointing in direction object is facing
        Vector2 currentAngleVect = new Vector2(Mathf.Cos(currentAngle * Mathf.Deg2Rad), Mathf.Sin(currentAngle * Mathf.Deg2Rad));

        //Formula for calculating the angle between two vectors 
        //cos theta = a dot b / abs a * abs b
        angleDelta = Mathf.Acos((Vector2.Dot(lookVect, currentAngleVect) / (lookVect.magnitude * currentAngleVect.magnitude))) * Mathf.Rad2Deg;

        if (angleDelta > 90)
        {
            transform.Rotate(0f, 0f, rotateScalar * Time.deltaTime * distance, Space.Self);
        }
        else if (angleDelta < 90)
        {
            transform.Rotate(0f, 0f, -rotateScalar * Time.deltaTime * distance, Space.Self);
        }

    }

}
