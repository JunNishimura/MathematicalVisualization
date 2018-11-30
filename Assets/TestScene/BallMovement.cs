using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour 
{
    private float radius;
    private float time;
    private float speed;
    private Rigidbody rb;
    private Vector3 newPos;
    private Vector3 startPos;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        radius = 4.0f;
        speed = 2.0f;
        startPos = this.transform.position;
    }

    private void Update()
    {
        time += Time.deltaTime * speed;
        float x = Mathf.Cos(time) * radius;
        //float x = 
        float y = Mathf.Sin(time) * radius;
        float z = Mathf.Sin(time) * Mathf.Cos(time) * radius;
        newPos = new Vector3(x, y, z);
        this.transform.position = newPos;
    }
}
