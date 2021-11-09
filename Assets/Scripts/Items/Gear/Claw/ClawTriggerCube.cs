using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawTriggerCube : MonoBehaviour
{

    public bool triggerEntered = false;
    public GameObject touching = null;
    public Vector3 liftPos;
    public bool lifting;

    void Start()
    {
        liftPos = new Vector3(0.0f, -0.5f, -1.0f);
    }

    void OnTriggerStay(Collider other)
    {
        // var characterName = other.name;
        // print(characterName);
        if(other.name == "IdleLuz" || other.name == "Brute" || other.name == "SatBot" || other.name == "Pump")
        {
            print(other.name);
            if(touching == null)
            {
                touching = other.gameObject; 
            }  
        }
        
    }

    void OnTriggerExit(Collider other)
     { 
            
        if(other.name == "IdleLuz" || other.name == "Brute" || other.name == "SatBot" || other.name == "Pump" || other.name.Contains("Box"))
        {   
            if(lifting == false)
            {
                // canLift = false;
                touching = null;
            }
        }
     }

    // Update is called once per frame
    void Update()
    {
        touching.transform.position = transform.TransformPoint(liftPos);
    }
}
