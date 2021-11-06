using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public GameObject OtherPortal;
    public Portal other_portal_script;
    public Vector3 sendToLocation;
    public bool canPortal = true;
    public bool portalIsActive = false;

    void Start() 
    {
        sendToLocation = OtherPortal.transform.position;
        other_portal_script = OtherPortal.GetComponent<Portal>();
    }

    void OnTriggerStay(Collider other)
    {
        var characterName = other.name;
        if(characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump" || characterName == "Brute" || characterName.Contains("Push"))
        {
           if(portalIsActive && canPortal)
           {
               other_portal_script.cantPortal();
               other.transform.position = sendToLocation;
           }
        }
    }

    void OnTriggerExit(Collider other)
    {
        var characterName = other.name;
        if(characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump" || characterName == "Brute")
        {
           
               canPortal = true;

           
        }

    }

    public void cantPortal()
    {
        canPortal = false;
    }

    public void makeActive()
    {
        portalIsActive = true;
    }
}
