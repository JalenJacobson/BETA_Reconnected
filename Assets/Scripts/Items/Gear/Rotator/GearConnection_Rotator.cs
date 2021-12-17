using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearConnection_Rotator : CDI_Class
{
    public GameObject Rotator;
    public Rotator RotatorMove_Script;
    // public Claw ClawDrop_Script;

    
    void Start()
    {
        anim = GetComponent<Animator>();
        RotatorMove_Script = Rotator.GetComponent<Rotator>();
        // ClawDrop_Script = Claw.GetComponent<Claw>();
    }

    
    void Update()
    {
        
    }
    
    public void Activate()
    {
        // RotatorMove_Script.Activate();
        
        // ClawBoundry_Script.Activate();
        // ClawDrop_Script.Activate();
    }

    public void connect()
    {
        anim.Play("ActivateGearBox");
        RotatorMove_Script.RotatorConnected = true;
        // RotatorMove_Script.anim.Play("Claw"); 
        // ClawBoundry_Script.clawConnected = !ClawBoundry_Script.clawConnected;
        // ClawDrop_Script.clawDrop = !ClawDrop_Script.clawDrop;

    }

    public void disconnect()
    {
        anim.Play("DeactivateGearBox");
        RotatorMove_Script.RotatorConnected = false;
        
         
        // ClawBoundry_Script.clawConnected = !ClawBoundry_Script.clawConnected;
        // ClawDrop_Script.clawDrop = !ClawDrop_Script.clawDrop;

    }
}
