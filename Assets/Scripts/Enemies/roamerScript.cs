using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roamerScript : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;

    GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("GameController");
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
