using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteTriggerCube : MonoBehaviour
{
    public Animator anim;
    public bool triggerEntered = false;
    public GameObject touching = null;
    public bool canLift = false;
    public Vector3 liftPos;
    public bool lifting;

    public GameObject ActionBrute;
    BruteBubbleScript Bubble_Script;
    public GameObject ActionLight;
    BruteBubbleScript Light_Script;
    public GameObject ActionCircles;
    BruteBubbleScript Circle_Script;
    
    public GameObject Cancel;
    CancelButton CancelButton_Script;
    public GameObject Brute;
    MoveBruteW AnimArms_Script;

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
        liftPos = new Vector3(0.0f, -0.5f, -1.0f);
        anim = GetComponent<Animator>();
        Bubble_Script = ActionBrute.GetComponent<BruteBubbleScript>();
        Light_Script = ActionLight.GetComponent<BruteBubbleScript>();
        Circle_Script = ActionCircles.GetComponent<BruteBubbleScript>();
        CancelButton_Script = Cancel.GetComponent<CancelButton>();
        AnimArms_Script = Brute.GetComponent<MoveBruteW>();
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
            Bubble_Script.actionBubbleStart();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart();   
        }
        
    }

     void OnTriggerExit(Collider other)
     { 
        var characterName = other.name;    
        if(characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump" || characterName.Contains("Box"))
        {   
            if(lifting == false)
            {
                canLift = false;
                touching = null;
            }
        Bubble_Script.actionBubbleStop();
        Light_Script.actionBubbleStop();
        Circle_Script.actionBubbleStop();
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
                }
                else if(lifting)
                {
                    drop();    
                }
            }
            
        }

        if(touching.name.Contains("Brute") && Input.GetKeyDown(activateKey))
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
        AnimArms_Script.Drop();  
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


 