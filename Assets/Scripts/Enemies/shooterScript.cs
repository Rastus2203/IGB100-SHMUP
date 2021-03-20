using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterScript : MonoBehaviour
{
    public float health = 50;
    public float maxHealth = 100;

    GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("GameController");
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
}
