using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_Connection_Crawler : CDI_Class
{

    public GameObject Stand;
    public Gear_Crawler StandMove_Script;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        StandMove_Script = Stand.GetComponent<Gear_Crawler>();
        liftPoint = Stand;
        botToIgnore = "Gears";
    }

    void connect()
    {
        callCameraFollow();
        anim.Play("ActivateGearBox");
        StandMove_Script.standConnected = true;
    }

    void disconnect()
    {
        callCameraUnfollow();
        anim.Play("DeactivateGearBox");
        StandMove_Script.standConnected = false;
    }
}
