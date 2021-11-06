using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteMove : Player
{
    // public float moveSpeed = 5;
    //public float rotateSpeed = 10;
    public GameObject TimerBarBrute;
    TimeBarBrute TimerBar_Script;
    

    void Start()
    {
        name = "Brute";
        moveSpeed = 7f;
        startPos = new Vector3(63.5f, 0.77f, -230f);
        transform.position = startPos;
        TimerBar_Script = TimerBarBrute.GetComponent<TimeBarBrute>();
        orangeGravityField = new Color(0.689f, 0.452f, 0.016f, 1.000f);
        greenConsole = new Color(0.0f, 1.0f, 0.1144f, 1.0f);
        blueCircuitField = new Color(0.06799023f, 0.5f, 0.8584906f, 1.0f);
        redDanger = new Color(1f, 0.1f, 0.0f, 1.0f);
    }
    
    public override void highGravityEnter ()
    {
        moveSpeed = 7;
    }
    public override void highGravityExit ()
    {
        moveSpeed = 7;
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
        resetConsoleDangerState();
        // DangerField.text = "Danger Area: None";
        resetConsoleDangerField();
        TimerBar_Script.timerStop();
        inWater = false;
        breathRemaining = 5f;
    }
}