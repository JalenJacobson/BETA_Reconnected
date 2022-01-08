using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatMove : Player
{
    // public Animator anim;
    

    // public GameObject TimerBarSat;
    // TimeBarSat TimerBar_Script;
    
    public GameObject Rails;
    SatBotAnim Rails_Script;

    public string moveAxisHorizontal;
    public string moveAxisVertical;
    public string playerNumber;

    public float StartHealth = 100;

    public GameObject MiniMap_Manager;
    public MiniMap MiniMap_Script;
    public string special;

    

    // public float currentHealth ;
    // public float maxHealth = 100f;

    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("SatPlayerNumber");
        getControls();
     }

    void Start()
    {
        MiniMap_Script = MiniMap_Manager.GetComponent<MiniMap>();
        anim = GetComponent<Animator>(); 
        name = "Sat";
        Rails_Script = Rails.GetComponent<SatBotAnim>();
        currentHealth = StartHealth;
        healthBar.setHealth(maxHealth);
        lose_condition = GameObject.Find("Lose_Conditions");
        lose_condition_script = lose_condition.GetComponent<Lose_Conditions>();
        // startPos = new Vector3(58f, 1.3f, -230f);
        // transform.position = startPos;
        
        // TimerBar_Script = TimerBarSat.GetComponent<TimeBarSat>();
        // orangeGravityField = new Color(0.689f, 0.452f, 0.016f, 1.000f);
        // greenConsole = new Color(0.0f, 1.0f, 0.1144f, 1.0f);
        // blueCircuitField = new Color(0.06799023f, 0.5f, 0.8584906f, 1.0f);
        // redDanger = new Color(1f, 0.1f, 0.0f, 1.0f);
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
            Rails_Script.rails();
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
            StartCoroutine(returnToStart("DeadSat"));
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

        if (Input.GetKeyDown(special))
        {
            MiniMap_Script.MiniMapToggle();
        }
        if (Input.GetButtonDown("special"))
        {
            MiniMap_Script.MiniMapToggle();
        }
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
        // resetConsoleDangerField();
        // resetConsoleDangerState();
        // TimerBar_Script.timerStop();
        inWater = false;
        breathRemaining = 5f;
    }

    public void death()
    {
        if(!isDying)
        {
            isDying = true;
            StartCoroutine(returnToStart("DeadSat"));
        }
        
    }

    // public void restoreHealth()
    // {
    //     while(currentHealth < maxHealth)
    //     {
    //         currentHealth+= 0.05f;
    //         print(currentHealth);
    //     }
        
    // }
}
