using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpMove : Player
{
    // public float moveSpeed = 7;
    // public float rotateSpeed = 10;
    // public Rigidbody rb;
    // public bool toggleSelected;
    // private Vector3 direction;
    // public Vector3 startPos;
    // public bool fixPosition = false;
    // public Joystick joystick;

    public GameObject PumpBlueWall;
    public BlueWall pumpBlueWall_script;
    // public Animator anim;
    public string moveAxisHorizontal;
    public string moveAxisVertical;
    public string special;
    public bool bubbleOpen;
    public string playerNumber;

    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("PumpPlayerNumber");
        getControls();
     }

    void Start()
    {   
        name = "Pump";
        currentHealth = maxHealth;
        pumpBlueWall_script = PumpBlueWall.GetComponent<BlueWall>();
        // transform.position = startPos;
        anim = GetComponent<Animator>();
        healthBar.setHealth(maxHealth);  
        lose_condition = GameObject.Find("Lose_Conditions");
        lose_condition_script = lose_condition.GetComponent<Lose_Conditions>();      
    }

    void getControls()
    {
        if(playerNumber == "P1")
        {
            moveAxisHorizontal = "Horizontal";
            moveAxisVertical = "Vertical";
            special = "space";
        }
        else if(playerNumber == "P2")
        {
            moveAxisHorizontal = "HorizontalPlayer2";
            moveAxisVertical = "VerticalPlayer2";  
            special = "return"; 
        }
    }

    // void FixedUpdate()
    // {
    //     if (toggleSelected == true && fixPosition == false){
    //         Movement();
    //     }
        
    // }

    public override void Movement()
    {
        float horizontalMove = Input.GetAxis(moveAxisHorizontal);
        float verticalMove = Input.GetAxis(moveAxisVertical);

        direction = new Vector3(horizontalMove, 0.0f, verticalMove);
        rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * direction);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
            currentHealth = currentHealth - .05f;
            anim.Play("PumpWalk");
            
        }
        
        
    }

    void Update()
    {
        if(inWater == true && Input.GetKeyDown(special))
        {
            if(bubbleOpen == false)
            {
                pumpBlueWall_script.Play();
                bubbleOpen = true;
            }
            else if(bubbleOpen == true)
            {
                pumpBlueWall_script.Stop();
                bubbleOpen = false;
            }
        }
        healthBar.setHealth(currentHealth);

        if(currentHealth <= 0)
        {
            batteryDead = true;
        }
        else if(currentHealth > 0)
        {
            batteryDead = false;
        }
    }

    public void waterEnter()
    {
        inWater = true;
    }
    public void waterExit()
    {
        inWater = false;
        bubbleOpen = false;
        pumpBlueWall_script.Stop();
    }

    public void death()
    {
        if(!isDying)
        {
            isDying = true;
            StartCoroutine(returnToStart("DeadPump"));
        }
        
    }

    // public void BlueWallOpen()
    // {
    //     blueWall = true;
    //     print("NUMBER2 this should open wall "+blueWall);
    //     //  anim.Play("BlueWallOpen");
    // }
    // public void BlueWallClose()
    // {
    //     blueWall = false;
    // }
}
