using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHealthbarScript : MonoBehaviour
{
    public GameObject boss;
    bossScript bScript;


    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(10, 0.5f, 1);
        boss = GameObject.FindWithTag("boss");
        bScript = boss.GetComponent<bossScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(bScript.health / 10, 0.5f, 1);
    }
}
