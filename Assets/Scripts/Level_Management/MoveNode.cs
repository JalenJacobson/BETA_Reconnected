using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MoveNode : MonoBehaviour
{
    public GameObject touching = null;     

    public float moveSpeed = 10;
    public float rotateSpeed = 10;
    public Vector3 directionMove;
    public Vector3 directionRotate;
    //public Joystick joystick;
    public Rigidbody rb;
    public string moveAxisHorizontal;
    public string moveAxisVertical;
    public bool fixRotation = false;
    public Vector3 startPos;
    public bool nodeEntered = false;

    public Vector2 moveInputValue;

    void Awake()
    {
        //directionMove = Vector3.zero;
        moveAxisHorizontal = "Horizontal";
        moveAxisVertical = "Vertical"; 
        transform.position = startPos;
    }
    void FixedUpdate()
    {
        directionMove = Vector3.zero;
        //Movement();

    }

    public void Movement(float x, float y)
    {
      //print("NODE MOVE SCRIPT" + x);
        //float horizontalMove = Input.GetAxis(moveAxisHorizontal);
        //float verticalMove = Input.GetAxis(moveAxisVertical);

        directionRotate = new Vector3(x, 0.0f, y);
        directionMove = new Vector3(x * moveSpeed, rb.velocity.y, y * moveSpeed);
        if(directionMove != Vector3.zero)
        {
            rb.velocity = directionMove;
            //currentHealth = currentHealth - .03f;
        }

        if (!fixRotation && directionRotate != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionRotate), rotateSpeed * Time.deltaTime);
        }

        // rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * direction);
        
    }

    // private void OnMove(InputValue value)
    // {
    //     moveInputValue = value.Get<Vector2>();
    //     print("GAMER" + Gamepad.current.displayName);
    // }

    public void Submit()
     {
        print("NEXTLEVEL");

        if(nodeEntered == true)
        {  
        touching.SendMessage("gotoLevel");
        }
     }

    void OnTriggerEnter(Collider other)
    {
        nodeEntered = true;

        if(other.name.Contains("LevelSelectPortal"))
      {
        touching = other.gameObject; 
      }
    }
    void OnTriggerExit(Collider other)
    {
        nodeEntered = false;

        if(other.name.Contains("LevelSelectPortal"))
      {
        touching = null; 
      }
    }
}