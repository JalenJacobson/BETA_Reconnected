using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors_BotConnection_Base : CDI_Class
{

    public GameObject Doors;
    public Doors Doors_script;
    private bool alreadyActivated = false;
    public bool Active = false;
    // Start is called before the first frame update
    void Start()
    {
        Doors_script = Doors.GetComponent<Doors>();
        quickLookObject = Doors;
        quickLookObjectOffset = new Vector3(-12f, 12f, 0f);
        quickLookWhenActivated = true;
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
                anim.Play("DisconnectButton");   
            }
            else anim.Play("SatDoorActivate");
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
    
    // public void Activate()
    // {   
    //     Active = true;      
    
    //     if(!alreadyActivated)
    //     {
    //         alreadyActivated = true;
    //         Doors_script.Activate();
    //         anim.Play("ButtonActive");
    //         anim.Play("PumpActivate");
    //         anim.Play("SatDoorActivate");
    //         anim.Play("LuzDoorActivate");
    //     }
    // }

    void Activate()
    {
        StartCoroutine(activateItemSequence());
    }

    public override void activateItem()
    {
        Active = true;      
    
        if(!alreadyActivated)
        {
            alreadyActivated = true;
            Doors_script.Activate();
            anim.Play("ButtonActive");
            anim.Play("PumpActivate");
            anim.Play("SatDoorActivate");
            anim.Play("LuzDoorActivate");
        }
    }
}
