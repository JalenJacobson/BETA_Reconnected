using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_Connection_Crawler : CDI_Class
{

    public GameObject gizmo;
    public Gear_Crawler gizmoMove_Script;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        gizmoMove_Script = gizmo.GetComponent<Gear_Crawler>();
        //liftPoint = Stand;
        botToIgnore = "Gears";
    }

    public void setGizmoInTriggerCube(GearTriggerCube triggerScript)
    {
      triggerScript.gizmoGear_Crawler_Script = gizmoMove_Script;
    }

    void connect()
    {
        //callCameraFollow();
        anim.Play("ActivateGearBox");
        gizmoMove_Script.standConnected = true;
    }

    void disconnect()
    {
        //callCameraUnfollow();
        anim.Play("GearsSpin");
        gizmoMove_Script.standConnected = false;
    }
}
