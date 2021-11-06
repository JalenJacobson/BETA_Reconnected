using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePortals : MonoBehaviour
{

    public GameObject PortalA;
    public Portal portala_script;
    public GameObject PortalB;
    public Portal portalb_script;
    // Start is called before the first frame update
    void Start()
    {
       portala_script = PortalA.GetComponent<Portal>();
       portalb_script = PortalB.GetComponent<Portal>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Activate()
    {
        portala_script.makeActive();
        portalb_script.makeActive();
    }
}
