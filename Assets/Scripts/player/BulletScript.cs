using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public bool isEnemy;
    public float speedScalar = 30f;
    public Vector2 velocity;
    public Vector2 direction;

    float damage = 20;

    float minX;
    float maxX;
    float minY;
    float maxY;

    string[] enemyTags = {"chaser", "shooter"};



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
        Debug.Log(string.Format("Collision with {0}", other.tag));
        if (inArray(enemyTags, other.tag))
        {
            other.SendMessage("damageCollider", damage);
            Destroy(this.gameObject);
        }

    }

    bool inArray(string[] strArray, string str)
    {
        for (int i=0; i < strArray.Length; i++)
        {
            if (str == strArray[i])
            {
                return true;
            }
        }
        return false;
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
