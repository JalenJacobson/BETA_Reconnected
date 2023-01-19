using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravaConnector : CDI_Class
{
    public GameObject GravaRotator;
    public GravaRotator GravaRotator_Script;
    public Animator Gravaanim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Gravaanim = GetComponent<Animator>();
        GravaRotator_Script = GravaRotator.GetComponent<GravaRotator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void setGravaInTriggerCube(SatTriggerCube triggerScript)
    {
      triggerScript.GravaRotator_Script = GravaRotator_Script;
      GravaRotator_Script.ActivateAnim();
      anim.Play("PortalBoxActive");
    }


    public void disconnect()
    {
        //anim.Play("DeactivateGearBox");
        GravaRotator_Script.DeactivateAnim();
        
    }
}
