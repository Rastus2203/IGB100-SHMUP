using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{
    float spawnTime;
    float waitLength = 0.2f;
    float damage = 20f;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        if (currentTime - spawnTime > waitLength)
        {
            Destroy(transform.gameObject);
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


    public void init(Transform preTransform)
    {
        transform.position = preTransform.position;
        transform.rotation = preTransform.rotation;
    }
}
