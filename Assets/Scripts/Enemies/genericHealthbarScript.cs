using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genericHealthbarScript : MonoBehaviour
{
    public float reportedHealth;



    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(10, 0.5f, 1);



    }

    // Update is called once per frame
    void Update()
    {

    }

    void updateBar(float health)
    {
        reportedHealth = health;
        transform.localScale = new Vector3(10 * health, 0.5f, 1);

        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    void updatePosition(Transform enemyTransform)
    {
        Transform parent = transform.parent;

        Vector3 enemyPosition = enemyTransform.position;
        float x = enemyPosition.x;
        float y = enemyPosition.y;
        float z = enemyPosition.z;

        parent.position = new Vector3(x, y + 0.8f, z);
    }
}
