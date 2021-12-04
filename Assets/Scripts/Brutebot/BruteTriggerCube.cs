using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteTriggerCube : MonoBehaviour
{
    public GameObject Brute;
    BruteMove BruteMove_Script;
    public bool triggerEntered = false;
    public GameObject touching = null;
    public bool canLift = false;
    public Vector3 liftPos;
    public bool lifting;




    // public GameObject TimerBarBrute;
    // TimeBarBrute TimerBarBrute_Script;

    public string playerNumber;
    public string connectKey;
    public string activateKey;
    public string disconnectKey;
    public string special;

    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("BrutePlayerNumber");
        getControls();
     }

    void Start()
    {
        BruteMove_Script = Brute.GetComponent<BruteMove>();
        liftPos = new Vector3(0.0f, -0.5f, -1.0f);

        // TimerBarBrute_Script = TimerBarBrute.GetComponent<TimeBarBrute>();
    }

    public void getControls()
    {
        if(playerNumber == "P1")
        {
            activateKey = "v";
            disconnectKey = "b";
            connectKey = "c";
            special = "space";
        }
        else if(playerNumber == "P2")
        {
            activateKey = "k";
            disconnectKey = "l";
            connectKey = "j";
            special = "return";
        }
    }

    void OnTriggerEnter(Collider other)
     {
          canLift = true;
            if(other.name.Contains("BatteryUI"))
            {
                touching = other.gameObject; 
            }   
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
        if(characterName.Contains("BatteryUI"))
        {
            touching = other.gameObject; 
        }
        
    }

     void OnTriggerExit(Collider other)
     { 
        var characterName = other.name;    
        if(characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump" || characterName.Contains("Box") || characterName.Contains("BatteryUI") || characterName.Contains("Brute"))
        {   
            if(lifting == false)
            {
                canLift = false;
                touching = null;
            }

        // lifting = false;
        }
     }

     

    void Update()
    {   
        if(Input.GetKeyDown(special))
        {
            if(touching.name == "IdleLuz" || touching.name == "Gears" || touching.name == "SatBot" || touching.name == "Pump")
            {
                if(!lifting)
                {
                    lift();
                    BruteMove_Script.Lift();
                }
                else if(lifting)
                {
                    drop();
                    BruteMove_Script.Drop();   
                }
            }
            
        }

        if(Input.GetKeyDown(activateKey))
        {
            Activate();
        }
    }

    public void Activate()
    {
        touching.SendMessage("Activate");
    }

     public void drop()
     {
        lifting = false;
        touching.SendMessage("toggleIsBeingCarried");
          
     }
    
    public void lift() 
    {
        if(touching.name == "IdleLuz" || touching.name == "Gears" || touching.name == "SatBot" || touching.name == "Pump")
        {
            lifting = true;
            // AnimArms_Script.Lift();
            touching.SendMessage("toggleIsBeingCarried");
            
        }
    }

}


 