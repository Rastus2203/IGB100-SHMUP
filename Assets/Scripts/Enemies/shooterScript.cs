using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterScript : MonoBehaviour
{
    public float health = 50;
    public float maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }

    void damageCollider(float damage)
    {
        health -= damage;
    }
}
