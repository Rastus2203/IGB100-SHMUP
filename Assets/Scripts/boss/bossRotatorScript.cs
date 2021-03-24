using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossRotatorScript : MonoBehaviour
{
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, 90 * Mathf.Sin(Time.time - startTime));
    }
}
