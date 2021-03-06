using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletScript : MonoBehaviour
{

    public bool isEnemy;
    public float speedScalar = 0f;
    public Vector2 velocity;
    public Vector2 direction;

    public float damage = 5;

    float minX;
    float maxX;
    float minY;
    float maxY;

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
    }

    void doMovement()
    {
        Vector3 position = transform.position;
        float x = position.x;
        float y = position.y;
        float z = position.z;
        transform.position = (new Vector3(x + velocity.x, y + velocity.y, z));


        if (x > maxX || x < minX || y > maxY || y < minY)
        {
            Destroy(gameObject);
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage("damageCollider", damage);
            Destroy(this.gameObject);
        }

    }


    //Not sure if there's a better way to pass arguements into a prefab.
    //This method is designed to be called directly after instantiating the prefab as a way of passing arguements.
    public void init(Vector2 ownerDirection, Vector3 ownerPosition, bool owner)
    {
        direction = ownerDirection;
        transform.position = ownerPosition;
        velocity = ownerDirection * speedScalar * Time.deltaTime;
        isEnemy = owner;
    }
}
