﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BruteMove : Player
{
    public string moveAxisHorizontal;
    public string moveAxisVertical;
    public string playerNumber;
    public GameObject BruteTriggerCube;
    public BruteTriggerCube BruteTrigger_Script;
    // public Image P1Circle;
    // public Image P2Circle;

    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("BrutePlayerNumber");
        
        BruteTriggerCube = GameObject.Find("BruteTriggerCube");
        BruteTrigger_Script = BruteTriggerCube.GetComponent<BruteTriggerCube>();
     }

    void Start()
    {
        anim = GetComponent<Animator>();
        name = "Brute";
        moveSpeed = 7f;
        currentHealth = maxHealth;
        healthBar.setHealth(maxHealth);
        lose_condition = GameObject.Find("Lose_Conditions");
        lose_condition_script = lose_condition.GetComponent<Lose_Conditions>();
        transform.position = startPos;
        Timer.drowning(breathRemaining);
        //getControls();
        //string[] GetJoystickNames();
        //P1Circle.spriteRenderer = GetComponent<SpriteRenderer>
        //P2Circle.spriteRenderer = GetComponent<SpriteRenderer>
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
    //         P1Circle.enabled = true;
    //         P2Circle.enabled = false;
    //     }
    //     else if(playerNumber == "P2")
    //     {
    //         moveAxisHorizontal = "HorizontalPlayer2";
    //         moveAxisVertical = "VerticalPlayer2";
    //         P1Circle.enabled = false;
    //         P2Circle.enabled = true;   
    //     }
    // }

    // public void ToggleCircle()
    // {
    //   P1Circle.enabled = true;  
    // }

    // public void ToggleCircleOff()
    // {
    //   P1Circle.enabled = false;  
    // }

    public void toggleToNext()
    {

    }
    
    public override void highGravityEnter ()
    {
        moveSpeed = 7;
    }
    public override void highGravityExit ()
    {
        moveSpeed = 7;
    }

    public override void Movement(float x, float y)
    {
        //float horizontalMove = Input.GetAxis(moveAxisHorizontal);
        //float verticalMove = Input.GetAxis(moveAxisVertical);

        directionRotate = new Vector3(x, 0.0f, y);
        directionMove = new Vector3(x * moveSpeed, rb.velocity.y, y * moveSpeed);
        if(currentHealth <= 0) return;
        if(directionMove != Vector3.zero)
        {
            rb.velocity = directionMove;
            currentHealth = currentHealth - .03f;
        }

        if (!fixRotation && directionRotate != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionRotate), rotateSpeed * Time.deltaTime);
        }

        // rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * direction);
        
    }

    void Update()
    {
        // if(ActivateCircle)
        // {
        //     P1Circle.enabled = true;
        // }
        // else if(!ActivateCircle)
        // {
        //     P1Circle.enabled = false;
        // }

        if(inWater == true)
        {
            if(!touchingAirBubble)
            {
                drowning();
            }
        }

        if(breathRemaining <= 0f)
        {
            // StartCoroutine(returnToStart("DeadBrute"));
            death();
            waterExit();
        }

        if(currentHealth <= 0)
        {
            batteryDead = true;
            anim.Play("BruteDeadBattery");
        }
        else if(currentHealth > 0)
        {
            batteryDead = false;
        }
        healthBar.setHealth(currentHealth);
    }

    public override void drowning()
    {
        if (breathRemaining > 0)
        {
            breathRemaining -= Time.deltaTime;
            Timer.drowning(breathRemaining);
        }
    }
    public override void waterExit()
    {
        inWater = false;
        breathRemaining = 5f;
        Timer.drowning(breathRemaining);
    }
    public void Lift()
    {
        anim.Play("Push");
    }
    public void Drop()
    {
        anim.Play("BruteWalk");
    }
    public void Activate()
    {
        anim.Play("Slam");
    }

    public void death()
    {
        if(!isDying)
        {
            isDying = true;
            if(BruteTrigger_Script.lifting)
            {
                BruteTrigger_Script.drop();
            }
            StartCoroutine(returnToStart("DeadBrute"));
        }
        
    }
    public void Sprint()
    {
        anim.Play("BruteSprint");
        StartCoroutine(BotSprint());
    }

}