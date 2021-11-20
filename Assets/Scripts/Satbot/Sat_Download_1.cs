using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sat_Download_1 : CDI_Class
{
   public string token = "1";
   public bool Active = false;
    // public GameObject forcegate_gate;
    // ForceGate forcegate_script;

    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        // forcegate_script = forcegate_gate.GetComponent<ForceGate>();
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
            if(botConnected)
            {
                anim.Play("DisconnectButton");    
            }
            else anim.Play("DownloadActivate");
        }

        else if(!Active)
        {
            if(botTouching == true)
            {
                if(botConnected)
                {
                    anim.Play("Connected");
                }
                else anim.Play("PushC");
            }
            else anim.Play("DisconnectedButtons");
 
        }  
    }

    void Activate()
    {
     Active = true;      
    }

}
