using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roamerScript : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;

    public Vector3 velocity;

    GameObject manager;
    float speedScalar = 5;

    float minX;
    float maxX;
    float minY;
    float maxY;

    public Vector2 test;

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

        float x = UnityEngine.Random.Range(-1f, 1f);
        float y = UnityEngine.Random.Range(-1f, 1f);

        test = new Vector2(x, y);

        velocity = new Vector3(x, y, 0);

        velocity = velocity / velocity.magnitude * speedScalar;
    }

    // Update is called once per frame
    void Update()
    {
        checkDead();

        Transform parent = transform.parent;
        GameObject healthbar = parent.Find("genericHealthbar/HealthProgress").gameObject;
        healthbar.SendMessage("updateBar", health / maxHealth);
        healthbar.SendMessage("updatePosition", transform);

        transform.position = transform.position + velocity * Time.deltaTime;

        if (transform.position.x < minX)
        {
            velocity.x = -velocity.x;
        }
        if (transform.position.x > maxX)
        {
            velocity.x = -velocity.x;
        }
        if (transform.position.y < minY)
        {
            velocity.y = -velocity.y;
        }
        if (transform.position.y > maxY)
        {
            velocity.y = -velocity.y;
        }



    }


    public void init(Vector3 spawnPosition)
    {
        transform.position = spawnPosition;
    }

    void damageCollider(float damage)
    {
        health -= damage;
    }


    void checkDead()
    {
        if (health <= 0)
        {
            Destroy(transform.parent.gameObject);

            manager.GetComponent<gameManager>().destroyed();
        }
    }
}
