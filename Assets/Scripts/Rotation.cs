using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotation : MonoBehaviour 
{
    // the velocity of target's rotation
    public Vector2 rotationSpeed;
    // the last mouse position
    private Vector2 lastMousePosition;
    // the angle of target
    private Vector2 newAngle = Vector2.zero;

    // menuUI
    [SerializeField] private GameObject ZoomSlider;

    private void Update()
    {
        // can be rotated when menuUI isn't active
        if (!ZoomSlider.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // when left button was pressed
                // store current angle into newAngle
                newAngle = transform.eulerAngles;
                // store the mouse position into lastMousePosition
                lastMousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                // while dragging the left button
                // the Y axis rotation
                newAngle.y += (lastMousePosition.x - Input.mousePosition.x) * rotationSpeed.y;
                // the x axis rotation
                newAngle.x -= (lastMousePosition.y - Input.mousePosition.y) * rotationSpeed.x;

                // change the angle of the target
                transform.eulerAngles = newAngle;
                // store the mosue position into lastMousePosition
                lastMousePosition = Input.mousePosition;
            }
        }
    }

    public void ResetRotation() 
    {
        transform.eulerAngles = Vector3.zero;
    }
}
