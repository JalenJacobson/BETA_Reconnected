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
    public Animator anim;
    public bool twoWayPortal = false;

    void Start() 
    {
        sendToLocation = OtherPortal.transform.position;
        other_portal_script = OtherPortal.GetComponent<Portal>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(portalIsActive == true)
        anim.Play("Portal1WayActivate");

        if(portalIsActive && canPortal == true)
        anim.Play("PortalActive");
    }

    void OnTriggerEnter(Collider other)
    {
        var characterName = other.name;
        if(characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump" || characterName.Contains("Brute") || characterName.Contains("Push"))
        {
           if(portalIsActive && canPortal)
           {
               portalTransport(other.gameObject);
           }
        }
    }

    void OnTriggerExit(Collider other)
    {
        var characterName = other.name;
        if(characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump" || characterName.Contains("Brute"))
        {
            if(!twoWayPortal) return;
            else StartCoroutine(twoWayPortalReactivate());
        }
        else if(characterName.Contains("Push"))
        {
            if(!canPortal)
            {
                other.GetComponent<Rigidbody>().isKinematic = true;
            }
            
        }

    }

    public void portalTransport(GameObject target)
    {
        if(target.name.Contains("Push"))
        {
            target.SendMessage("boxInPortal");
        }
        // else
        // {
            other_portal_script.cantPortal();
            target.transform.position = sendToLocation;
            target.GetComponent<Rigidbody>().isKinematic = false;
        // }
    }

    public void cantPortal()
    {
        canPortal = false;
    }

    public void makeActive()
    {
        portalIsActive = true;
    }

    public IEnumerator twoWayPortalReactivate()
    {
        yield return new WaitForSeconds(3);
        canPortal = true;
    }
}
