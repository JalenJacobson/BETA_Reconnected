using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearConnection_Rotator : CDI_Class
{
    public GameObject gizmo;
    public Rotator gizmoMove_Script;
    // public Claw ClawDrop_Script;

    
    void Start()
    {
        anim = GetComponent<Animator>();
        gizmoMove_Script = gizmo.GetComponent<Rotator>();
        // ClawDrop_Script = Claw.GetComponent<Claw>();
    }

    
    void Update()
    {
        
    }

    public void setGizmoInTriggerCube(GearTriggerCube triggerScript)
    {
      triggerScript.gizmoRotator_Script = gizmoMove_Script;
    }
    
    public void Activate()
    {
        // gizmoMove_Script.Activate();
        
        // ClawBoundry_Script.Activate();
        // ClawDrop_Script.Activate();
    }

    public void connect()
    {
        anim.Play("ActivateGearBox");
        gizmoMove_Script.RotatorConnected = true;
        // gizmoMove_Script.anim.Play("Claw"); 
        // ClawBoundry_Script.clawConnected = !ClawBoundry_Script.clawConnected;
        // ClawDrop_Script.clawDrop = !ClawDrop_Script.clawDrop;

    }

    public void disconnect()
    {
        anim.Play("GearsSpin");
        gizmoMove_Script.RotatorConnected = false;
        
         
        // ClawBoundry_Script.clawConnected = !ClawBoundry_Script.clawConnected;
        // ClawDrop_Script.clawDrop = !ClawDrop_Script.clawDrop;

    }
}
