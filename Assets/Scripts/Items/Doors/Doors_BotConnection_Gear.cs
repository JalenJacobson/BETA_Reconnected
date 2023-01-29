using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors_BotConnection_Gear : CDI_Class
{

    public GameObject Doors;
    public Doors Doors_script;
    private bool alreadyActivated = false;
    public bool Active = false;
    // Start is called before the first frame update
    void Start()
    {
        Doors_script = Doors.GetComponent<Doors>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // InfoButtons();

    }

    void InfoButtons()
    {
        if(Active == true)
        {
            if(botConnected)
            {
                anim.Play("DisconnectGearButtons");    
            }
            else anim.Play("ActivateGearBox");
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
    public void Activate()
    {   
        Active = true;      
    
        if(!alreadyActivated)
        {
            alreadyActivated = true;
            Doors_script.Activate();
            anim.Play("ButtonActive");
            anim.Play("PumpActivate");
            anim.Play("SatDoorActivate");
            anim.Play("ActivateGearBox");
        }
    }
}
