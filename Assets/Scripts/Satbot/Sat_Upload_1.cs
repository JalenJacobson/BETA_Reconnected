
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sat_Upload_1 : CDI_Class
{
    public string token = "1";
    public GameObject forcegate_gate;
    public ForceGate forcegate_script;
    
    public LevelComplete levelcomplete_script;
    public bool Active = false;
    
    void Start()
    {
        forcegate_script = forcegate_gate.GetComponent<ForceGate>();
        //quickLookObject = forcegate_gate;
        //quickLookObjectOffset = new Vector3(0.0f, 0.1f, -0.05f);
        //quickLookWhenActivated = true;
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        InfoButtons();
    }
    
    void InfoButtons()
    {
        if(Active == true)
        {
            anim.Play("SatDoorActivate");
        }
 
    }
    
    void Activate()
    {
        StartCoroutine(activateItemSequence());
    }

    public override void activateItem()
    {
        forcegate_script.toggleActive();
        Active = true; 
    }
}
