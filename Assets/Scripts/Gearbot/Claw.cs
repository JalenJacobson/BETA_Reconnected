using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour
{
    public GameObject ClawTriggerCube;
    public Vector3 ClawTriggerPos;
    public Animator anim;
    public float speed;
    public Vector3 direction;
    public string moveAxisHorizontal;
    public string moveAxisVertical;
    public float moveSpeed = 10;
    public float rotateSpeed = 10;
    public Rigidbody rb;
    public bool clawConnected = false;
    public bool clawDrop = false;
    public bool clawCarrying = false;
    public Transform target;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public Transform target5;


    void Awake()
    {
        moveAxisHorizontal = PlayerPrefs.GetString("GearAxisHorizontal");
        moveAxisVertical = PlayerPrefs.GetString("GearAxisVertical");
    }

    void Start () 
    {
        anim = GetComponent<Animator>();
        ClawTriggerPos = new Vector3(0.0f, -0.5f, -1.0f);
    }

    void FixedUpdate()
    {
        if(clawConnected == true)
        {
            Movement();
            anim.Play("Claw"); 
        }
    }

    void Update () 
    {
        ClawTriggerCube.transform.position = transform.TransformPoint(ClawTriggerPos);
    }

    public void Activate()
    {
        if(!clawCarrying)
        {
            anim.Play("ClawDrop");
            //this will need to be a coroutine
            //claw drops and closes
            //set lifting to true
            //claw lifts;
        }
        else if(clawCarrying)
        {
            // This needs to be an animation of the claw opening
        }
        
    }

    void Movement()
    {
        float horizontalMove = Input.GetAxis(moveAxisHorizontal);
        float verticalMove = Input.GetAxis(moveAxisVertical);

        direction = new Vector3(horizontalMove, 0.0f, verticalMove);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
            
        }

        rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * direction);
        // sendPos();
    }
 }

    // public void changeGearBox2()
    // {
    //     print("worked");
    //     gearBox2 = !gearBox2; 
    // }
