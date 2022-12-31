using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteTriggerCube : TriggerCubeBase
{
    public GameObject Brute;
    BruteMove BruteMove_Script;
    public bool triggerEntered = false;
    public GameObject touching = null;
    public GameObject batteryTouching = null;
    public bool canLift = false;
    public Vector3 liftPos;

    // public int controllingPlayer = 0;
    
    public bool lifting;

    // public string playerNumber;
    // public string connectKey;
    // public string activateKey;
    // public string disconnectKey;
    // public string special;
    // public string activateController;
    // public string specialController;

    void Awake()
    {
        playerNumber = PlayerPrefs.GetString("BrutePlayerNumber");
        
    }

    void Start()
    {
        BruteMove_Script = Brute.GetComponent<BruteMove>();
        liftPos = new Vector3(0.0f, -0.5f, -1.0f);
        getControls();
    }

    // public override void getControls()
    // {
    //     if(playerNumber == "P0") return;
    //     else if(playerNumber == "P1")
    //     {
    //         activateKey = "v";
    //         disconnectKey = "b";
    //         connectKey = "c";
    //         special = "space";
    //         activateController = "activate1";
    //         specialController = "special1";
    //     }
    //     else if(playerNumber == "P2")
    //     {
    //         activateKey = "k";
    //         disconnectKey = "l";
    //         connectKey = "j";
    //         special = "return";
    //         activateController = "activate2";
    //         specialController = "special2";
    //     }
    // }

    // public override void setCurrentPlayer(int player)
    // {
    //     controllingPlayer = player;
    //     playerNumber = "P" + player.ToString();
    //     getControls();
    // }

    void OnTriggerEnter(Collider other)
     {
            canLift = true; 
     }

    void OnTriggerStay(Collider other)
    {
        var characterName = other.name;
        if(characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump" ||characterName.Contains("Brute"))
        {
            if(touching == null)
            {
                touching = other.gameObject; 
            }
        }
        else if(other.name.Contains("BatteryUI"))
        {
            batteryTouching = other.gameObject;   
        }
        else if(other.name.Contains("Push"))
        {
            if(touching == null)
            {
                touching = other.gameObject;
                BruteMove_Script.anim.Play("Push");
            }
        }  
        
    }

     void OnTriggerExit(Collider other)
     { 
        if(other.name.Contains("Push"))
        {
            if(!lifting)
            {
                BruteMove_Script.anim.Play("BruteWalk");
                touching = null;
            }
           
        } 
        var characterName = other.name;    
        if(characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump" || characterName.Contains("Box") || characterName.Contains("Brute"))
        {   
            if(lifting == false)
            {
                canLift = false;
                touching = null;
            }
        }
        else if(characterName.Contains("BatteryUI"))
        {
            batteryTouching = null;
        }
     }

     

    void Update()
    {   
        // if(Input.GetKeyDown(special) || Input.GetButtonDown(specialController))
        // {
        //     if(touching.name == "IdleLuz" || touching.name == "Gears" || touching.name == "SatBot" || touching.name == "Pump" || touching.name.Contains("Push"))
        //     {
        //         if(!lifting)
        //         {
        //             lift();
        //             BruteMove_Script.Lift();
        //         }
        //     }
        // }
        // else if(Input.GetKeyUp(special) || Input.GetButtonUp(specialController))
        // {
        //     if(lifting)
        //     {
        //         drop();
        //         BruteMove_Script.Drop();   
        //     }
        // }
        // if(Input.GetKeyDown(activateKey))
        // {
        //     Activate();
        //     if (lifting == false && touching == null)
        //     {
        //         BruteMove_Script.Sprint();
        //     } 
        // }
        // if(Input.GetButtonDown(activateController))
        // {
        //     Activate();
        //     if (lifting == false && touching == null)
        //     {
        //     BruteMove_Script.Sprint();
        //     } 
        // }

    }

    public override void Special()
    {
        if(touching.name == "IdleLuz" || touching.name == "Gears" || touching.name == "SatBot" || touching.name == "Pump")
        {
            if(!lifting)
            {
                lift();
                BruteMove_Script.Lift();
            }
        }
        else if(lifting)
        {
            drop();
            BruteMove_Script.Drop();   
        }
        else 
        {
            return;
            // it could play a buzzer noise or something to show that the button cant do anything beause he isn't connected.
        }
    }

    public override void Activate()
    {
        if(touching)
        {
            if(touching.name.Contains("Doors") || touching.name.Contains("Button"))
            {
                BruteMove_Script.Activate();
                touching.SendMessage("Activate");
            }
        }
        if(batteryTouching)
        {
            batteryTouching.SendMessage("Activate");
        }
        
    }

    public void drop()
    {
        
        lifting = false;
        touching.SendMessage("toggleIsBeingCarried");
        BruteMove_Script.fixRotation = false;
        print("AABBAA" + BruteMove_Script.isDying);
        if(BruteMove_Script.isDying)
        {
            touching = null;
        }
    }
    
    public void lift() 
    {
        if(touching.name == "IdleLuz" || touching.name == "Gears" || touching.name == "SatBot" || touching.name == "Pump")
        {
            lifting = true;
            touching.SendMessage("toggleIsBeingCarried"); 
        }
        // if(touching.name.Contains("Push"))
        // {
            
        //     lifting = true;
        //     BruteMove_Script.fixRotation = true;
            
        //     touching.SendMessage("toggleIsBeingCarried");
        // }
    }
}


 