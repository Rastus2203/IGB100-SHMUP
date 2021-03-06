using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserScript : MonoBehaviour
{
    float minX;
    float maxX;
    float minY;
    float maxY;

    float damage = 5;

    GameObject player;
    Vector3 lookVect;
    public float lookAngle;
    public float speed = 5;
    public float rotateScalar = -1;
    public float distanceScalar = 10;

    public float health = 1;
    public float maxHealth = 1;

    public float angleDelta;

    Rigidbody objRigidBody;
    GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        objRigidBody = GetComponent<Rigidbody>();
        manager = GameObject.FindWithTag("GameController");

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


    //Not sure if there's a better way to pass arguements into a prefab.
    //This method is designed to be called directly after instantiating the prefab as a way of passing arguements.
    public void init(Vector3 spawnPosition)
    {
        transform.position = spawnPosition;
    }


    // Update is called once per frame
    void Update()
    {
        checkDead();
        Transform parent = transform.parent;
        GameObject healthbar = parent.Find("genericHealthbar/HealthProgress").gameObject;
        healthbar.SendMessage("updateBar", health / maxHealth);

        healthbar.SendMessage("updatePosition", transform);



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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage("damageCollider", damage);
            manager.GetComponent<gameManager>().destroyed();
            Destroy(transform.parent.gameObject);

        }

    }

    void checkDead()
    {
        if (health <= 0)
        {
            Destroy(transform.parent.gameObject);
            manager.GetComponent<gameManager>().destroyed();
        }
    }

    void damageCollider(float damage)
    {
        health -= damage;
    }



    void turnToPlayer()
    {
        //Slowly rotate object to face the player

        float distance = (30 - Vector3.Distance(transform.position, player.transform.position)) * distanceScalar;


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
