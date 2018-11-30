using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 関係ない
public class CamController : MonoBehaviour 
{
    public Transform target;

    private float radius = 5.0f;
    private float time;
    private float pi;
    private Vector3 newPos = Vector3.zero;
    private Vector2 mousePos = Vector2.zero;

    private void Awake()
    {
        pi = Mathf.PI;

        newPos.x = radius * Mathf.Cos(pi * mousePos.x);
        newPos.z = radius * Mathf.Sin(pi * mousePos.x);
    }

    private void Update()
    {
        time = Time.time;
        mousePos.x += Input.GetAxis("Horizontal") * Time.deltaTime;
        mousePos.y += Input.GetAxis("Vertical") * Time.deltaTime;
        //mousePos.y = Mathf.Clamp(mousePos.y, -0.3f + 0.5f, 0.3f + 0.5f);

        if (mousePos.x != 0.0f)
        {
            newPos.x = radius * Mathf.Cos(pi * mousePos.x);
            newPos.z = radius * Mathf.Sin(pi * mousePos.x);
        }

        if (mousePos.y != 0.0f)
        {
            newPos.y = radius * Mathf.Cos(pi * mousePos.y);
            newPos.z = radius * Mathf.Sin(pi * mousePos.y);
        }




        transform.position = target.position + newPos;
        transform.LookAt(target);
    }
}
