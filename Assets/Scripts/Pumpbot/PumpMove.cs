using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public string specialController;
    public bool bubbleOpen;
    public string playerNumber;
    public Image P1Circle;
    public Image P2Circle;
    

    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("PumpPlayerNumber");
        
     }

    void Start()
    {   
       // getControls();
        name = "Pump";
        currentHealth = maxHealth;
        pumpBlueWall_script = PumpBlueWall.GetComponent<BlueWall>();
        // transform.position = startPos;
        anim = GetComponent<Animator>();
        healthBar.setHealth(maxHealth);  
        lose_condition = GameObject.Find("Lose_Conditions");
        lose_condition_script = lose_condition.GetComponent<Lose_Conditions>();      
    }

    public override void setCurrentPlayer(int player)
    {
        controllingPlayer = player;
        playerNumber = "P" + player.ToString();
        //getControls();
    }

    // void getControls()
    // {
    //     if(playerNumber == "P0")
    //     {
    //         P1Circle.enabled = false;
    //         P2Circle.enabled = false;
    //     }
    //     else if(playerNumber == "P1")
    //     {
    //         moveAxisHorizontal = "Horizontal";
    //         moveAxisVertical = "Vertical";
    //         special = "space";
    //         specialController = "special1";
    //         P1Circle.enabled = true;
    //         P2Circle.enabled = false;
    //     }
    //     else if(playerNumber == "P2")
    //     {
    //         moveAxisHorizontal = "HorizontalPlayer2";
    //         moveAxisVertical = "VerticalPlayer2";  
    //         special = "return";
    //         specialController = "special2"; 
    //         P1Circle.enabled = false;
    //         P2Circle.enabled = true;  
    //     }
    // }

    // void FixedUpdate()
    // {
    //     if (toggleSelected == true && fixPosition == false){
    //         Movement();
    //     }
        
    // }


    public override void Movement(float x, float y)
    {

        directionRotate = new Vector3(x, 0.0f, y);
        directionMove = new Vector3(x * moveSpeed, rb.velocity.y, y * moveSpeed);
        
        rb.velocity = directionMove;

        if (!fixRotation && directionRotate != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionRotate), rotateSpeed * Time.deltaTime);
            currentHealth = currentHealth - .05f;
            anim.Play("PumpWalk");
        }

        // rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * direction);
        
    }

    void Update()
    {
        // if(inWater == true && Input.GetKeyDown(special) ||inWater == true && Input.GetButtonDown(specialController))
        // {
        //     if(bubbleOpen == false)
        //     {
        //         pumpBlueWall_script.Play();
        //         bubbleOpen = true;
        //     }
        //     else if(bubbleOpen == true)
        //     {
        //         pumpBlueWall_script.Stop();
        //         bubbleOpen = false;
        //     }
        // }
        healthBar.setHealth(currentHealth);

        if(currentHealth <= 0)
        {
            batteryDead = true;
            anim.Play("PumpDeadBattery");
        }
        else if(currentHealth > 0)
        {
            batteryDead = false;
        }

        if(isBeingCarried == true)
        {
          anim.Play("PumpBeingCarried");  
        }
    }

    public void openBubble()
    {
        if(inWater == true)
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
        else return;
    }
    

    public void waterEnter()
    {
        inWater = true;
    }
    public void waterDrain()
    {
        anim.Play("PumpWaterHose");
    }
    public void pumpBlow()
    {
        anim.Play("PumpBlowingHose");
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
