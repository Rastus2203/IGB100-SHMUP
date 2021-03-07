using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPivotScript : MonoBehaviour
{
    public Vector2 mouseDelta;
    public float rotationAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateToMouse();
    }

    //Rotates the player to face the current mouse position.
    void rotateToMouse()
    {
        //Gets the mouse position relative to the player to store in mouseDelta
        Vector3 mousePosition3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosition2 = new Vector2(mousePosition3.x, mousePosition3.y);
        Vector2 currentPosition = transform.position;
        mouseDelta = mousePosition2 - currentPosition;

        //Reset the viewing angle. transform.Rotate rotates relative to the current angle so this is necessary.
        //There is almost definitely a better way to do the rotation, but this works.
        Quaternion rotation = Quaternion.LookRotation(new Vector3(0, 0, 0));
        transform.rotation = rotation;

        //Gets the angle between the player and the mouse, then rotates.
        rotationAngle = Mathf.Atan2(mouseDelta.y, mouseDelta.x) * Mathf.Rad2Deg - 90;
        transform.Rotate(0, 0, rotationAngle, Space.Self);

    }
}
