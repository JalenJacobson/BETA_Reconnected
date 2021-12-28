using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzMove : Player
{
    public string moveAxisHorizontal;
    public string moveAxisVertical;
    public string playerNumber;
    // public Animator anim;
    public string special;


    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("LuzPlayerNumber");
        getControls();
     }

    void Start()
    {
        anim = GetComponent<Animator>();
        name = "Luz";
        currentHealth = maxHealth;
        healthBar.setHealth(maxHealth);
        breathRemaining = .1f;
        lose_condition = GameObject.Find("Lose_Conditions");
        lose_condition_script = lose_condition.GetComponent<Lose_Conditions>();
        // startPos = new Vector3(-180f, .5f, -98.5f);
        transform.position = startPos;
        // orangeGravityField = new Color(0.689f, 0.452f, 0.016f, 1.000f);
        // greenConsole = new Color(0.0f, 1.0f, 0.1144f, 1.0f);
        // blueCircuitField = new Color(0.06799023f, 0.5f, 0.8584906f, 1.0f);
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

    public override void Movement()
    {
        float horizontalMove = Input.GetAxis(moveAxisHorizontal);
        float verticalMove = Input.GetAxis(moveAxisVertical);

        directionRotate = new Vector3(horizontalMove, 0.0f, verticalMove);
        directionMove = new Vector3(horizontalMove * moveSpeed, rb.velocity.y, verticalMove * moveSpeed);
        rb.velocity = directionMove;

        if (!fixRotation && directionRotate != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionRotate), rotateSpeed * Time.deltaTime);
            currentHealth = currentHealth - .05f;
        }

        // rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * direction);
        
    }

     void Update()
    {

        if(inWater == true)
        {
            if(touchingAirBubble == true)
            {
                // DangerState.text = "Danger State: Short Circuit - Delayed";
                //setConsoleDangerField("Circuit Field", blueCircuitField);
               // setConsoleDangerState("Short Circuit - Delayed", greenConsole);
            }
            else
            {
                // DangerState.text = "Danger State: Short Circuit - Danger";
               // setConsoleDangerField("Circuit Field", blueCircuitField);
               // setConsoleDangerState("Short Circuit - Danger", redDanger);
                drowning();
            }
            
        }

        if(breathRemaining <= 0f)
        {
            returnToStart("DeadLuz");
            waterExit();
        }

        if(currentHealth <= 0)
        {
            batteryDead = true;
        }
        else if(currentHealth > 0)
        {
            batteryDead = false;
        }
        
        if (Input.GetKeyDown(special))
        {
            anim.Play("Recharge");
            currentHealth = currentHealth - 10f;
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
    public override void pumpAirBubbleEnter()
    {
        breathRemaining = .1f;
        touchingAirBubble = true;
    }

    public override void waterExit()
    {
        // DangerState.text = "Danger State: None";
        // DangerField.text = "Danger Area: None";
       // resetConsoleDangerField();
       // resetConsoleDangerState();
        inWater = false;
        breathRemaining = .1f;
    }

    public void Recharge()
    {

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
