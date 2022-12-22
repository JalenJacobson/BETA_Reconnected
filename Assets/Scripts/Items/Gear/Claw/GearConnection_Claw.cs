using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearConnection_Claw : CDI_Class
{

    public GameObject Claw;
    public Claw ClawMove_Script;

    // public GameObject liftPoint;

    public List<GameObject> ClawBoundries;
    public List<ClawBoundries> ClawBoundries_Scripts;
    // public Claw ClawDrop_Script;

    
    void Start()
    {
        anim = GetComponent<Animator>();
        ClawMove_Script = Claw.GetComponent<Claw>();
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
    
    public void Activate()
    {
        ClawMove_Script.Activate();
        
        // ClawBoundry_Script.Activate();
        // ClawDrop_Script.Activate();
    }

    public void connect()
    {
        //callCameraFollow();
        anim.Play("ActivateGearBox");
        ClawMove_Script.clawConnected = true;
        ClawMove_Script.anim.Play("Claw");

        foreach(ClawBoundries ClawBoundries_Script in ClawBoundries_Scripts)
        {
            ClawBoundries_Script.clawConnected = true;
        } 
    }

    public void disconnect()
    {
        //callCameraUnfollow();
        anim.Play("DeactivateGearBox");
        ClawMove_Script.clawConnected = false;
        if(ClawMove_Script.lifting)
        {
            ClawMove_Script.touching.GetComponent<Rigidbody>().useGravity = true;
            ClawMove_Script.lifting = false;
            ClawMove_Script.clawCarrying = false;
            ClawMove_Script.anim.Play("ClawDrop");
        }
        else if(ClawMove_Script.lifting == false)
        {
            ClawMove_Script.anim.Play("ClawEnd");
        }

        foreach(ClawBoundries ClawBoundries_Script in ClawBoundries_Scripts)
        {
            ClawBoundries_Script.clawConnected = false;
        }
         
        // ClawBoundry_Script.clawConnected = !ClawBoundry_Script.clawConnected;
        // ClawDrop_Script.clawDrop = !ClawDrop_Script.clawDrop;

    }
}
