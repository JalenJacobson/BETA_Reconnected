using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMove : Player
{
    // public GameObject TimerBarGear;
    // public TimeBarGear TimerBar_Script;
    public string moveAxisHorizontal;
    public string moveAxisVertical;
    public string playerNumber;
    public float StartHealth = 100;
    // public Animator anim;

    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("GearPlayerNumber");
        getControls();
     }

    void Start()
    {
        anim = GetComponent<Animator>();
        name = "Gears";
        currentHealth = StartHealth;
        healthBar.setHealth(maxHealth);
        lose_condition = GameObject.Find("Lose_Conditions");
        lose_condition_script = lose_condition.GetComponent<Lose_Conditions>();
        // startPos = new Vector3(47f, 1.44f, -231f);
        // transform.position = startPos;
        // TimerBar_Script = TimerBarGear.GetComponent<TimeBarGear>();
        // orangeGravityField = new Color(0.689f, 0.452f, 0.016f, 1.000f);
        // greenConsole = new Color(0.0f, 1.0f, 0.1144f, 1.0f);
        // blueCircuitField = new Color(0.06799023f, 0.5f, 0.8584906f, 1.0f);
        // redDanger = new Color(1f, 0.1f, 0.0f, 1.0f);
    }

    void getControls()
    {
        print(playerNumber);
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

    public override void Movement()
    {
        if(currentHealth > 0)
        {
            float horizontalMove = Input.GetAxis(moveAxisHorizontal);
            float verticalMove = Input.GetAxis(moveAxisVertical);

            direction = new Vector3(horizontalMove, 0.0f, verticalMove);

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
                currentHealth = currentHealth - .05f;
            }

            rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * direction);
        }
        
        // sendPos();
    }

    void Update()
    {
        if(inWater == true)
        {
            if(touchingAirBubble == true)
            {
                // DangerState.text = "Danger State: Short Circuit - Delayed";
                // setConsoleDangerField("Circuit Field", blueCircuitField);
                // setConsoleDangerState("Short Circuit - Delayed", greenConsole);
                
                // TimerBar_Script.enterbluewall();
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
            StartCoroutine(returnToStart("Dead"));
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

        healthBar.setHealth(currentHealth);
    }
    public override void drowning()
    {
        // print("drowning");
        // TimerBar_Script.timerStart();
        if (breathRemaining > 0)
        {
            breathRemaining -= Time.deltaTime;
        }
    }
    public override void waterExit()
    {
        // DangerState.text = "Danger State: None";
        // DangerField.text = "Danger Area: None";
       // resetConsoleDangerField();
       // resetConsoleDangerState();
        // TimerBar_Script.timerStop();
        inWater = false;
        breathRemaining = 5f;
    }


    public void death()
    {
        StartCoroutine(returnToStart("Dead"));
    }

    //  public void restoreHealth()
    // {
    //     currentHealth = maxHealth;
    // }
}
