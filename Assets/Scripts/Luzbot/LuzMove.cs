﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuzMove : Player
{
    public string moveAxisHorizontal;
    public string moveAxisVertical;
    public string playerNumber;
    // public Animator anim;
    // public string special = "v";
    // public string specialController = "v";
    // public Image P1Circle;
    // public Image P2Circle;


    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("LuzPlayerNumber");
        
     }

    void Start()
    {
        anim = GetComponent<Animator>();
        name = "Luz";
        currentHealth = maxHealth;
        healthBar.setHealth(maxHealth);
        breathRemaining = 1f;
        lose_condition = GameObject.Find("Lose_Conditions");
        lose_condition_script = lose_condition.GetComponent<Lose_Conditions>();
        // startPos = new Vector3(-180f, .5f, -98.5f);
        startPos = transform.position;
        Timer.drowning(breathRemaining);
        getIconSelectors();
        //nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public override void setCurrentPlayer(int player)
    {
        controllingPlayer = player;
        playerNumber = "P" + player.ToString();
        
    }

   

    public override void Movement(float x, float y)
    {
        directionRotate = new Vector3(x, 0.0f, y);
        directionMove = new Vector3(x * moveSpeed, rb.velocity.y, y * moveSpeed);
        if(currentHealth <= 0) return;
        if(directionMove != Vector3.zero)
        {
            rb.velocity = directionMove;
            currentHealth = currentHealth - .03f;
        }
        else if(directionMove == Vector3.zero)
        {
            rb.velocity = Vector3.zero;
        }

        if (!fixRotation && directionRotate != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionRotate), rotateSpeed * Time.deltaTime);
            currentHealth = currentHealth - .01f;
        }

        
        
    }

    

     void Update()
    {
        //rb.AddForce(0, -100, 0);
       if(shouldFollowTeamBot && available)
        {
           // nav.SetDestination(botToFollowWhenUnoccupied.position);
            Follow.enabled = true;
            GetToFollow.enabled = false;
            //rb.drag = 10;
            //coll.material = physicMaterial1;
        }
        else if(!shouldFollowTeamBot && available)
        {
            Follow.enabled = false;
            GetToFollow.enabled = true;
            //rb.drag = 10;
            //coll.material = physicMaterial1;
        }
        else if(!available)
        {
            Follow.enabled = false;
            GetToFollow.enabled = false;
            //rb.drag = 0;
            // if(currentHealth <= 0)
            // {
            //     coll.material = physicMaterial1;
            // }
            // else if(currentHealth > 0)
            // {
            //     coll.material = physicMaterial2;
            // }
            
        }

        if(inWater == true)
        {
            if(touchingAirBubble == true)
            {
                
            }
            else
            {
                
                drowning();
            }
            
        }

        if(breathRemaining <= 0f)
        {
            death();
            waterExit();
        }

        if(currentHealth <= 0)
        {
            batteryDead = true;
            anim.Play("LuzDeadBattery");
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
    public override void pumpAirBubbleEnter()
    {
        breathRemaining = 1f;
        touchingAirBubble = true;
        Timer.drowning(breathRemaining);
    }

        // public void ToggleCircle()
        // {
        //     P1Circle.enabled = true;  
        // }

        // public void ToggleCircleOff()
        // {
        //     P1Circle.enabled = false;  
        // }

    public override void waterExit()
    {
        // DangerState.text = "Danger State: None";
        // DangerField.text = "Danger Area: None";
       // resetConsoleDangerField();
       // resetConsoleDangerState();
        inWater = false;
        breathRemaining = 1f;
        Timer.drowning(breathRemaining);
    }

    public void Recharge()
    {
        anim.Play("Recharge");
        currentHealth = currentHealth - 10f;
    }

    public void death()
    {
        if(!isDying)
        {
            isDying = true;
            StartCoroutine(returnToStart("DeadLuz"));
        }
        
    }
    

    // public void restoreHealth()
    // {
    //     currentHealth = maxHealth;
    // }
}
