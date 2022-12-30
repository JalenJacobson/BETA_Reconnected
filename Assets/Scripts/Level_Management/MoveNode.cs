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
        Movement();

    }

    public void Movement()
    {
        directionRotate = new Vector3(moveInputValue.x, 0.0f, moveInputValue.y);
        directionMove = new Vector3(moveInputValue.x * moveSpeed, rb.velocity.y, moveInputValue.y * moveSpeed);
        if(directionMove != Vector3.zero)
        {
            rb.velocity = directionMove;
        }

        if (!fixRotation && directionRotate != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionRotate), rotateSpeed * Time.deltaTime);
        }

    }

    private void OnMove(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
        print("GAMER" + Gamepad.current.displayName);
    }

    private void OnSubmit()
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