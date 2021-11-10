using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearConnection_Claw : MonoBehaviour
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

    public void toggleClawConnected()
    {
        ClawMove_Script.clawConnected = !ClawMove_Script.clawConnected;
        ClawMove_Script.anim.Play("Claw"); 
        // ClawBoundry_Script.clawConnected = !ClawBoundry_Script.clawConnected;
        // ClawDrop_Script.clawDrop = !ClawDrop_Script.clawDrop;

    }

}
