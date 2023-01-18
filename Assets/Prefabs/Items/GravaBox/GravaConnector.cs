using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravaConnector : CDI_Class
{
    public GameObject GravaRotator;
    public GravaRotator GravaRotator_Script;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        GravaRotator_Script = GravaRotator.GetComponent<GravaRotator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void setGravaInTriggerCube(SatTriggerCube triggerScript)
    {
      triggerScript.GravaRotator_Script = GravaRotator_Script;
    }

     public void connect()
    {
        //anim.Play("ActivateGearBox");
        GravaRotator_Script.RotatorConnected = true;

    }

    public void disconnect()
    {
        //anim.Play("DeactivateGearBox");
        GravaRotator_Script.RotatorConnected = false;
        
    }
}
