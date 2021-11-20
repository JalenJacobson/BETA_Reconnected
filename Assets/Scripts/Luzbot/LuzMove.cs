using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzMove : Player
{
    public string moveAxisHorizontal;
    public string moveAxisVertical;
    public string playerNumber;
    public Animator anim;
    public string special;

    public healthBar healthBar;

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
        startPos = new Vector3(-180f, .5f, -98.5f);
        transform.position = startPos;
        orangeGravityField = new Color(0.689f, 0.452f, 0.016f, 1.000f);
        greenConsole = new Color(0.0f, 1.0f, 0.1144f, 1.0f);
        blueCircuitField = new Color(0.06799023f, 0.5f, 0.8584906f, 1.0f);
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

        direction = new Vector3(horizontalMove, 0.0f, verticalMove);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
            currentHealth = currentHealth - .025f;
        }

        rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * direction);
        // sendPos();
    }

     void Update()
    {

        if(inWater == true)
        {
            if(touchingAirBubble == true)
            {
                // DangerState.text = "Danger State: Short Circuit - Delayed";
                setConsoleDangerField("Circuit Field", blueCircuitField);
                setConsoleDangerState("Short Circuit - Delayed", greenConsole);
            }
            else
            {
                // DangerState.text = "Danger State: Short Circuit - Danger";
                setConsoleDangerField("Circuit Field", blueCircuitField);
                setConsoleDangerState("Short Circuit - Danger", redDanger);
                drowning();
            }
            
        }

        if(breathRemaining <= 0f)
        {
            returnToStart();
            waterExit();
        }
        
        if (Input.GetKeyDown(special))
        {
            anim.Play("Recharge");
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
        resetConsoleDangerField();
        resetConsoleDangerState();
        inWater = false;
        breathRemaining = .1f;
    }

    public void Recharge()
    {

    }

    public void restoreHealth()
    {
        currentHealth = maxHealth;
    }
}
