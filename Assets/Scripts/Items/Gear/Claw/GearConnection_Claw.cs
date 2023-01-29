using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearConnection_Claw : CDI_Class
{

    public GameObject gizmo;
    public Claw gizmoMove_Script;

    // public GameObject liftPoint;

    public List<GameObject> ClawBoundries;
    public List<ClawBoundries> ClawBoundries_Scripts;
    // public Claw ClawDrop_Script;

    
    void Start()
    {
        anim = GetComponent<Animator>();
        gizmoMove_Script = gizmo.GetComponent<Claw>();
        getClawBoundriesScripts();
        botToIgnore = "Gears";
        // liftPoint = GameObject.Find("pGear1");
        // ClawDrop_Script = Claw.GetComponent<Claw>();
    }

    
    void Update()
    {
        
    }
    public void getClawBoundriesScripts()
    {
        foreach(GameObject ClawBoundries in ClawBoundries)
        {
            var ClawBoundries_Script = ClawBoundries.GetComponent<ClawBoundries>();
            ClawBoundries_Scripts.Add(ClawBoundries_Script);
        }
    }

    public void setGizmoInTriggerCube(GearTriggerCube triggerScript)
    {
      triggerScript.gizmoClaw_Script = gizmoMove_Script;
    }
    
    public void Activate()
    {
        gizmoMove_Script.Activate();
        
        // ClawBoundry_Script.Activate();
        // ClawDrop_Script.Activate();
    }

    public void connect()
    {
        //callCameraFollow();
        anim.Play("ActivateGearBox");
        gizmoMove_Script.clawConnected = true;
        gizmoMove_Script.anim.Play("Claw");

        foreach(ClawBoundries ClawBoundries_Script in ClawBoundries_Scripts)
        {
            ClawBoundries_Script.clawConnected = true;
        } 
    }

    public void disconnect()
    {
        //callCameraUnfollow();
        anim.Play("GearsSpin");
        gizmoMove_Script.clawConnected = false;
        if(gizmoMove_Script.lifting)
        {
            gizmoMove_Script.touching.GetComponent<Rigidbody>().useGravity = true;
            gizmoMove_Script.lifting = false;
            gizmoMove_Script.clawCarrying = false;
            gizmoMove_Script.anim.Play("ClawDrop");
        }
        else if(gizmoMove_Script.lifting == false)
        {
            gizmoMove_Script.anim.Play("ClawEnd");
        }

        foreach(ClawBoundries ClawBoundries_Script in ClawBoundries_Scripts)
        {
            ClawBoundries_Script.clawConnected = false;
        }
         
        // ClawBoundry_Script.clawConnected = !ClawBoundry_Script.clawConnected;
        // ClawDrop_Script.clawDrop = !ClawDrop_Script.clawDrop;

    }
}
