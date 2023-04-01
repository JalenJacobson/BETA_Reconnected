using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerFollow : MonoBehaviour
{

    public GameObject target;
    public float speed = 1.0f;
    private Transform targetPosition;
    public Rigidbody rb;
    public Vector3 directionMove;
    public float moveSpeed = 10;

    void Start()
    {
        targetPosition = target.transform;
    }



    void Update() 
     {
        var step =  speed * Time.deltaTime; // calculate distance to move
        rb.velocity = Vector3.MoveTowards(transform.position, targetPosition.position, step);
     }

    public void Movement(float x, float y)
    {
        directionMove = new Vector3(x * moveSpeed, rb.velocity.y, y * moveSpeed);
        rb.velocity = directionMove;
    }

}
