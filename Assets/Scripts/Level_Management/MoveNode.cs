using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveNode : MonoBehaviour
{
    public float moveSpeed = 10;
    public Vector3 directionMove;
    public Joystick joystick;
    public Rigidbody rb;

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        float horizontalMove = joystick.Horizontal;
        float verticalMove = joystick.Vertical;
        directionMove = new Vector3(horizontalMove * moveSpeed, rb.velocity.y, verticalMove * moveSpeed);
        rb.velocity = directionMove;
    }
}