using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMove : Player
{
    public GameObject TimerBarGear;
    public TimeBarGear TimerBar_Script;
    public string moveAxisHorizontal;
    public string moveAxisVertical;

    void Awake()
     {
        moveAxisHorizontal = PlayerPrefs.GetString("GearAxisHorizontal");
        moveAxisVertical = PlayerPrefs.GetString("GearAxisVertical");
     }

    void Start()
    {
        name = "Gears";
        // startPos = new Vector3(47f, 1.44f, -231f);
        // transform.position = startPos;
        TimerBar_Script = TimerBarGear.GetComponent<TimeBarGear>();
        orangeGravityField = new Color(0.689f, 0.452f, 0.016f, 1.000f);
        greenConsole = new Color(0.0f, 1.0f, 0.1144f, 1.0f);
        blueCircuitField = new Color(0.06799023f, 0.5f, 0.8584906f, 1.0f);
        redDanger = new Color(1f, 0.1f, 0.0f, 1.0f);
    }

    public override void Movement()
    {
        float horizontalMove = Input.GetAxis(moveAxisHorizontal);
        float verticalMove = Input.GetAxis(moveAxisVertical);

        direction = new Vector3(horizontalMove, 0.0f, verticalMove);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
            
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
                
                TimerBar_Script.enterbluewall();
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
    }
    public override void drowning()
    {
        // print("drowning");
        TimerBar_Script.timerStart();
        if (breathRemaining > 0)
        {
            breathRemaining -= Time.deltaTime;
        }
    }
    public override void waterExit()
    {
        // DangerState.text = "Danger State: None";
        // DangerField.text = "Danger Area: None";
        resetConsoleDangerField();
        resetConsoleDangerState();
        TimerBar_Script.timerStop();
        inWater = false;
        breathRemaining = 5f;
    }
}
