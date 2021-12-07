using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteMove : Player
{
    // public float moveSpeed = 5;
    //public float rotateSpeed = 10;
    // public Animator anim;
    public GameObject TimerBarBrute;
    TimeBarBrute TimerBar_Script;
    public string moveAxisHorizontal;
    public string moveAxisVertical;
    public string playerNumber;


    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("BrutePlayerNumber");
        getControls();
     }

    void Start()
    {
        anim = GetComponent<Animator>();
        name = "Brute";
        moveSpeed = 7f;
        currentHealth = maxHealth;
        healthBar.setHealth(maxHealth);
        // startPos = new Vector3(-180, 0.77f, -111f);
        transform.position = startPos;
        TimerBar_Script = TimerBarBrute.GetComponent<TimeBarBrute>();
        orangeGravityField = new Color(0.689f, 0.452f, 0.016f, 1.000f);
        greenConsole = new Color(0.0f, 1.0f, 0.1144f, 1.0f);
        blueCircuitField = new Color(0.06799023f, 0.5f, 0.8584906f, 1.0f);
        redDanger = new Color(1f, 0.1f, 0.0f, 1.0f);
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

        direction = new Vector3(horizontalMove, 0.0f, verticalMove);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
            currentHealth = currentHealth - .05f;
        }

        rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * direction);
        // sendPos();
    }

    void Update()
    {
        if(inWater == true)
        {
            print("brute in water");
            if(touchingAirBubble == true)
            {
                // DangerState.text = "Danger State: Short Circuit - Delayed";
                // setConsoleDangerField("Circuit Field", blueCircuitField);
                // setConsoleDangerState("Short Circuit - Delayed", greenConsole);
                TimerBar_Script.enterbluewall();
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
            StartCoroutine(returnToStart());
            waterExit();
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
        // resetConsoleDangerState();
        // DangerField.text = "Danger Area: None";
        // resetConsoleDangerField();
        // TimerBar_Script.timerStop();
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
       void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Hole") || other.name.Contains("fire"))
        {     
            currentHealth = currentHealth - 20f;
            anim.Play("DeadBrute");    
        }
    }
}