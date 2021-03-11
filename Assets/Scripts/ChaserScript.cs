using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserScript : MonoBehaviour
{
    GameObject player;
    Vector3 lookVect;
    public float lookAngle;
    float rotateScalar = 5;
    public float a;

    public float current;
    public float playerA;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");


        lookVect = player.transform.position - transform.position;

        transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 0));
        lookAngle = Mathf.Atan2(lookVect.y, lookVect.x) * Mathf.Rad2Deg - 90;
        transform.Rotate(0, 0, lookAngle, Space.Self);

    }

    // Update is called once per frame
    void Update()
    {
        lookVect = player.transform.position - transform.position;
        Vector3 currentRotation = transform.eulerAngles;

        lookAngle = (Mathf.Atan2(lookVect.y, lookVect.x) * Mathf.Rad2Deg - currentRotation.z) % 360;
        current = currentRotation.z;
        playerA = Mathf.Atan2(lookVect.y, lookVect.x) * Mathf.Rad2Deg;

        float oldRotation = currentRotation.z;
        /*
        if (lookAngle > 0 && lookAngle < 180)
        {
            //transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 0));
            //lookAngle = Mathf.Atan2(lookVect.y, lookVect.x) * Mathf.Rad2Deg - 90;
            transform.Rotate(0, 0, rotateScalar * Time.deltaTime, Space.Self);
        } else if (lookAngle > 180 && lookAngle < 360)
        {
            //transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 0));
            //lookAngle = Mathf.Atan2(lookVect.y, lookVect.x) * Mathf.Rad2Deg - 90;
            transform.Rotate(0, 0, rotateScalar * Time.deltaTime, Space.Self);
        }
        */
            

    }

}
