using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveNode : MonoBehaviour
{
    public float moveSpeed = 10;
    public float rotateSpeed = 10;
    public Vector3 directionRotate;
    public Vector3 directionMove;
    public string moveAxisHorizontal;
    public string moveAxisVertical;
    public string playerNumber;
    public Joystick joystick;
    public Rigidbody rb;

    virtual public void Start()
    {

    }

    void Joystick()
    {
        moveAxisHorizontal = "joystick.Horizontal";
        moveAxisVertical = "joystick.Vertical";
    }

    public void Movement()
    {
        float horizontalMove = Input.GetAxis(moveAxisHorizontal);
        float verticalMove = Input.GetAxis(moveAxisVertical);

        directionRotate = new Vector3(horizontalMove, 0.0f, verticalMove);
        directionMove = new Vector3(horizontalMove * moveSpeed, rb.velocity.y, verticalMove * moveSpeed);
        rb.velocity = directionMove;



        // rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * direction);
        
    }

    
}
