using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveNode : MonoBehaviour
{
    public float moveSpeed = 10;
    public Vector3 directionMove;
    //public Joystick joystick;
    public Rigidbody rb;
    public string moveAxisHorizontal;
    public string moveAxisVertical;

    void Awake()
    {
        directionMove = Vector3.zero;
        moveAxisHorizontal = "Horizontal";
        moveAxisVertical = "Vertical"; 
    }
    void Update()
    {

        Movement();

    }

    public void Movement()
    {
        float horizontalMove = Input.GetAxis(moveAxisHorizontal);
        float verticalMove = Input.GetAxis(moveAxisVertical);        
        directionMove = new Vector3(horizontalMove * moveSpeed, rb.velocity.y, verticalMove * moveSpeed);

        rb.velocity = directionMove;

    }
}