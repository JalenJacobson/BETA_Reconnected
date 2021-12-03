using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sat_Upload_1 : CDI_Class
{
    public string token = "1";
    public GameObject forcegate_gate;
    public ForceGate forcegate_script;
    
    public GameObject StartPort;
    public LevelComplete levelcomplete_script;
    public bool Active = false;

    
    // Start is called before the first frame update
    void Start()
    {
        forcegate_script = forcegate_gate.GetComponent<ForceGate>();
        levelcomplete_script = StartPort.GetComponent<LevelComplete>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InfoButtons();
    }
    
        void InfoButtons()
    {
        if(Active == true)
        {
            anim.Play("UploadActive");
        }
 
    }
    
    void Activate()
    {
        forcegate_script.toggleActive();
        Active = true; 
    }

    // void Activate(string uploadType)
    // {
    //     if(uploadType == "forceGate")
    //     {
    //         forcegate_script.forceGateDown();
    //     }
    //     else if(uploadType == "endGame")
    //     {
    //         print("activate endgame sequence");
    //         levelcomplete_script.deliverVirus();
    //     }
        
    // }
}
