using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Vector3 boxPos;
    public GameObject Brute;
    public BruteMove BruteMove_Script;
    public bool isBeingCarried = false;
    public string size = "small";

    public Vector3 directionx;
    public Vector3 directionz;
    public Vector3 direction;
    public string moveAxisHorizontal;
    public string moveAxisVertical;
    public float moveSpeed = 4;
    public Rigidbody rb;
    public Animator anim;
    public GameObject touching = null;

    // public Vector3 boxFallLocation;
    // public float boxFallTimeDelta = 30f;
    
    void Awake()
    {
        moveAxisHorizontal = PlayerPrefs.GetString("BruteAxisHorizontal");
        moveAxisVertical = PlayerPrefs.GetString("BruteAxisVertical");
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Brute = GameObject.Find("Brute");
        BruteMove_Script = Brute.GetComponent<BruteMove>();
        moveSpeed = 4f;
        getBoxSize();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(isBeingCarried)
        {
            // transform.position = Brute.transform.position + boxPos;
            // GetComponent<Rigidbody>().useGravity = false;
            MovementX();
        }
        else if(!isBeingCarried)
        {
        //    GetComponent<Rigidbody>().useGravity = true; 
        }
    }

     public void toggleIsBeingCarried()
    {
        if(!isBeingCarried)
        {
            gameObject.AddComponent<FixedJoint>();
            gameObject.GetComponent<FixedJoint>().connectedBody=Brute.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            isBeingCarried = true;
        }
        else if(isBeingCarried && touching)
        {  
            rb.isKinematic = false;
            isBeingCarried = false;  
            Destroy(gameObject.GetComponent<FixedJoint>());
        }
        else if(isBeingCarried && touching == null)
        {
            isBeingCarried = false;  
            Destroy(gameObject.GetComponent<FixedJoint>());
            rb.isKinematic = true;
        }
    }

    public void getBoxSize()
    {
        if(size == "small")
        {
            boxPos = new Vector3(0f, 0f, .03f);
        }
        if(size == "medium")
        {
            boxPos = new Vector3(-7.5f, 0f, 0f);
        }
        if(size == "large")
        {
            boxPos = new Vector3(0f, 0f, .06f);
        }
    }

    void MovementX()
    {

        print("should move x");
        float horizontalMove = Input.GetAxis(moveAxisHorizontal);
        float verticalMove = Input.GetAxis(moveAxisVertical);

        directionx = new Vector3(horizontalMove, 0.0f, 0.0f);

        // if (direction != Vector3.zero)
        // {
        //     transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
            
        // }

        rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * directionx);
        // sendPos();
    }

    public void boxFall()
    {
        StartCoroutine(boxFallTime()); 
    }

    void OnTriggerStay(Collider other)
    {
        // var characterName = other.name;
        if(other.name.Contains("BoxTrigger"))
        {
            print(other.name);
            if(touching == null)
            {
                touching = other.gameObject; 
            }  
        }
        
    }

    IEnumerator boxFallTime()
    {
        BruteMove_Script.fixRotation = true;
        BruteMove_Script.fixPosition = true;
        rb.isKinematic = false;
        isBeingCarried = false;
        Destroy(gameObject.GetComponent<FixedJoint>());
        // transform.position = Vector3.MoveTowards(transform.position, targetBoxFall.transform.position, drainTimeDelta);
        yield return new WaitForSeconds(1f);
        BruteMove_Script.fixRotation = false;
        BruteMove_Script.fixPosition = false;
        
    }
}

