using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawTriggerCube : MonoBehaviour
{

    public bool triggerEntered = false;
    public GameObject touching = null;
    
    

    public GameObject Claw;
    public Claw ClawMove_Script;

    void Start()
    {
        ClawMove_Script = Claw.GetComponent<Claw>();
    }

    void OnTriggerStay(Collider other)
    {
        // var characterName = other.name;
        if(other.name == "IdleLuz" || other.name == "Brute" || other.name == "SatBot" || other.name == "Pump" || other.name.Contains("MineCrawler"))
        {       
            if(touching == null)
            {
                print(other.name);
                touching = other.gameObject; 
                ClawMove_Script.touching = other.gameObject;
            }  
        }
        
    }

    void OnTriggerExit(Collider other)
    {   
        if(other.name == "IdleLuz" || other.name == "Brute" || other.name == "SatBot" || other.name == "Pump" || other.name.Contains("Box") || other.name.Contains("MineCrawler"))
        {   
            if(ClawMove_Script.clawCarrying) return;
            print(other.name);
            touching = null;
            ClawMove_Script.touching = null;
        }
    }

    
    void Update()
    {
        
    }
}
