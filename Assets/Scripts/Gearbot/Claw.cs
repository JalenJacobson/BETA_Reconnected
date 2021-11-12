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
    public bool lifting = false;
    public bool clawCarrying = false;
    public Vector3 liftPos;
    public Transform target;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public Transform target5;

    public GameObject liftPoint;

    public GameObject touching = null;


    void Awake()
    {
        moveAxisHorizontal = PlayerPrefs.GetString("GearAxisHorizontal");
        moveAxisVertical = PlayerPrefs.GetString("GearAxisVertical");
    }

    void Start () 
    {
        anim = GetComponent<Animator>();
        ClawTriggerPos = new Vector3(0.0f, -0.5f, -1.0f);
        // liftPos = new Vector3(0.0f, -0.005f, 0.0f);
    }

    void FixedUpdate()
    {
        if(clawConnected == true)
        {
            Movement();
        }
    }

    void Update () 
    {
        if(lifting)
        {
            touching.transform.position = liftPoint.transform.TransformPoint(liftPos);
            touching.GetComponent<Rigidbody>().useGravity = false;
        }
        else touching.GetComponent<Rigidbody>().useGravity = true;
    }

    public void Activate()
    {
        if(!clawCarrying && touching)
        {
            clawCarrying = true;
            StartCoroutine(clawPickUp());
        }
        else if(clawCarrying)
        {
            clawCarrying = false;
            anim.Play("ClawOpen");
            lifting = false;
            // This needs to be an animation of the claw opening
        }
        
    }

    IEnumerator clawPickUp()
    {
        anim.Play("ClawClose");
        yield return new WaitForSeconds(1);
        lifting = true;
        yield return new WaitForSeconds(.5f);
        anim.Play("ClawPickUp");
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
 }
