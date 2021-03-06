using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteMove : Player
{
    public string moveAxisHorizontal;
    public string moveAxisVertical;
    public string playerNumber;
    public GameObject BruteTriggerCube;
    public BruteTriggerCube BruteTrigger_Script;

    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("BrutePlayerNumber");
        getControls();
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
    }

    void getControls()
    {
        if(playerNumber == "P1")
        {
            moveAxisHorizontal = "Horizontal";
            moveAxisVertical = "Vertical";
        }
        else if(playerNumber == "P2")
        {
            moveAxisHorizontal = "HorizontalPlayer2";
            moveAxisVertical = "VerticalPlayer2";   
        }
    }
    
    public override void highGravityEnter ()
    {
        moveSpeed = 7;
    }
    public override void highGravityExit ()
    {
        moveSpeed = 7;
    }

    public override void Movement()
    {
        float horizontalMove = Input.GetAxis(moveAxisHorizontal);
        float verticalMove = Input.GetAxis(moveAxisVertical);

        directionRotate = new Vector3(horizontalMove, 0.0f, verticalMove);
        directionMove = new Vector3(horizontalMove * moveSpeed, rb.velocity.y, verticalMove * moveSpeed);
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
        }
    }
    public override void waterExit()
    {
        inWater = false;
        breathRemaining = 5f;
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