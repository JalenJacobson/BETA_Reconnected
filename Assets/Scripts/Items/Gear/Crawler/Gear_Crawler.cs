using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_Crawler : MonoBehaviour
{
     public Animator anim;
    public Vector3 directionx;
    public Vector3 directionz;
    public Vector3 direction;
    public string moveAxisHorizontal;
    public string moveAxisVertical;
    public float moveSpeed = 100;
    public Rigidbody rb;
    public bool xMove = false;
    public bool zMove = false;
    public bool standConnected = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
        moveAxisHorizontal = PlayerPrefs.GetString("GearAxisHorizontal");
        moveAxisVertical = PlayerPrefs.GetString("GearAxisVertical");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(standConnected)
        {
            anim.Play("GearStandActivate");
            if(xMove && zMove)
            {
                Movement();
            }
            else if(xMove)
            {
                MovementX();
            }
            else if(zMove)
            {
                MovementZ();
            }
        }
        else if(standConnected == false)
        {
        anim.Play("GearStandDeactivate");  
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
    void MovementZ()
    {
        print("should move z");
        float horizontalMove = Input.GetAxis(moveAxisHorizontal);
        float verticalMove = Input.GetAxis(moveAxisVertical);

        directionz = new Vector3(0.0f, 0.0f, verticalMove);

        // if (direction != Vector3.zero)
        // {
        //     transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
            
        // }

        rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * directionz);
        // sendPos();
    }
    public void Movement(float x, float y)
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

    public void toggleX()
    {
        xMove = !xMove;
    }

    public void toggleZ()
    {
        zMove = !zMove;
    }

    public void standConnect()
    {
        anim.Play("GearStandActivate");
        standConnected = true;
    }

    public void standDisconnected()
    {
        anim.Play("GearStandDeactivate");
        standConnected = false;
    }

    
}
