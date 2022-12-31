
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour
{
    public GameObject ClawTriggerCube;
    // public GameObject Camera;
    public TwoPlayerCameraFollow CameraFollow_Script;
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
    public bool lifting = false;
    public bool clawCarrying = false;
    public Vector3 liftPos;

    public GameObject liftPoint;

    public GameObject touching = null;

    // public bool sentCameraConnecteMessage = false;
    // public bool sentCameraDisconnecteMessage = false;
    public bool sentCameraLiftConnecteMessage = false;
    public bool sentCameraLiftDisconnecteMessage = false;


    void Awake()
    {
        moveAxisHorizontal = PlayerPrefs.GetString("GearAxisHorizontal");
        moveAxisVertical = PlayerPrefs.GetString("GearAxisVertical");
        // Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Start () 
    {
        anim = GetComponent<Animator>();
        ClawTriggerPos = new Vector3(0.0f, -0.5f, -1.0f);
        liftPos = new Vector3(0.0f, -0.03f, 0.0f);
        CameraFollow_Script = GameObject.Find("TwoPlayerCameraFollow").GetComponent<TwoPlayerCameraFollow>();
    }

    void FixedUpdate()
    {
        if(clawConnected == true)
        {
            Movement();
            // callCameraFollow();
        }
        else if(!clawConnected)
        {
            // callCameraUnfollow();
            //touching.SendMessage("isNotBeingCarried");
        }
        if(lifting)
        {
            touching.transform.position = liftPoint.transform.TransformPoint(liftPos);
            touching.GetComponent<Rigidbody>().isKinematic = true;
        }
        else if(!lifting)
        {
            touching.GetComponent<Rigidbody>().isKinematic = false;
            callCameraFollowUnlift();
        }
           
        
        
    }

    void Update () 
    {
        
    }

    public void Activate()
    {
        if(!clawCarrying && touching && !lifting)
        {
            clawCarrying = true;
            StartCoroutine(clawPickUp());
        }
        else if(clawCarrying)
        {
            clawCarrying = false;
            anim.Play("ClawOpen");
            lifting = false;
            touching.SendMessage("isNotBeingCarried");
            touching.SendMessage("Explode");
        }
        
    }

    IEnumerator clawPickUp()
    {
        anim.Play("ClawClose");
        yield return new WaitForSeconds(.3f);
        lifting = true;
        touching.SendMessage("IsBeingCarried");
        yield return new WaitForSeconds(.25f);
        anim.Play("ClawPickUp");
        // touching.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Movement()
    {
        float horizontalMove = Input.GetAxis(moveAxisHorizontal);
        float verticalMove = Input.GetAxis(moveAxisVertical);

        direction = new Vector3(horizontalMove, 0.0f, verticalMove);

        // if (direction != Vector3.zero)
        // {
        //     transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
            
        // }

        rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * direction);
        // sendPos();
    }

    // public void callCameraFollow()
    // {
    //     if(!sentCameraConnecteMessage)
    //     {
    //         sentCameraConnecteMessage = true;
    //         sentCameraDisconnecteMessage = false;
    //         CameraFollow_Script.followObject(liftPoint, "Gears");
    //     }
    // }
    // public void callCameraUnfollow()
    // {
    //     if(!sentCameraDisconnecteMessage)
    //     {
    //         sentCameraDisconnecteMessage = true;
    //         sentCameraConnecteMessage = false;
    //         CameraFollow_Script.unfollowObject();
    //     }
    // }
    public void callCameraFollowLift()
    {
        if(!sentCameraLiftConnecteMessage)
        {
            sentCameraLiftConnecteMessage = true;
            sentCameraLiftDisconnecteMessage = false;
            CameraFollow_Script.clawCarrying = true;
        }
    }
    public void callCameraFollowUnlift()
    {
        if(!sentCameraLiftDisconnecteMessage)
        {
            sentCameraLiftDisconnecteMessage = true;
            sentCameraLiftConnecteMessage = false;
            CameraFollow_Script.clawCarrying = false;
        }
    }

    
 }
