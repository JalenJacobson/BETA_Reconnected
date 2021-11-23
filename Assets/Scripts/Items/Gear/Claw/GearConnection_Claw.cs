using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearConnection_Claw : CDI_Class
{

    public GameObject Claw;
    public Claw ClawMove_Script;
    // public Claw ClawDrop_Script;
    public GameObject ClawBoundries;
    public ClawBoundries ClawBoundry_Script;

    
    void Start()
    {
        ClawMove_Script = Claw.GetComponent<Claw>();
        // ClawDrop_Script = Claw.GetComponent<Claw>();
        ClawBoundry_Script = ClawBoundries.GetComponent<ClawBoundries>();
    }

    
    void Update()
    {
        
    }
    
    public void Activate()
    {
        ClawMove_Script.Activate();
        
        // ClawBoundry_Script.Activate();
        // ClawDrop_Script.Activate();
    }

    public void ClawConnected()
    {
        ClawMove_Script.clawConnected = true;
        ClawMove_Script.anim.Play("Claw"); 
        // ClawBoundry_Script.clawConnected = !ClawBoundry_Script.clawConnected;
        // ClawDrop_Script.clawDrop = !ClawDrop_Script.clawDrop;

    }

    public void ClawDisonnected()
    {
        ClawMove_Script.clawConnected = false;
        if(ClawMove_Script.lifting)
        {
            ClawMove_Script.touching.GetComponent<Rigidbody>().useGravity = true;
            ClawMove_Script.lifting = false;
            ClawMove_Script.clawCarrying = false;
        }
        ClawMove_Script.anim.Play("ClawDrop"); 
        // ClawBoundry_Script.clawConnected = !ClawBoundry_Script.clawConnected;
        // ClawDrop_Script.clawDrop = !ClawDrop_Script.clawDrop;

    }
}
