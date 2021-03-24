using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDashBarScript : MonoBehaviour
{
    public GameObject player;
    PlayerScript pScript;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(10, 0.5f, 1);
        player = GameObject.FindWithTag("Player");
        pScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(pScript.dashBarProgress / 10, 0.5f, 1);
    }
}
