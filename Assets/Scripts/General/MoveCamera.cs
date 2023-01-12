using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float moveSpeed = 10;
    public float rotateSpeed = 10;
    public Vector3 directionMove;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Movement(float x, float y)
    {
        directionMove = new Vector3(x * moveSpeed, rb.velocity.y, y * moveSpeed);
        rb.velocity = directionMove;
    }
}
