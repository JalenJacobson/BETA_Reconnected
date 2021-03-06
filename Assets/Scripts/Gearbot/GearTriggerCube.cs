using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearTriggerCube : MonoBehaviour
{
    public GameObject Gears;
    GearMove GearMove_Script;

    public Text Connection;
    public Text ErrorMessage;
    
    public bool triggerEntered = false;
    public bool connected = false;
    public GameObject touching = null;
    public Vector3 connectPos;

    // public GameObject ActionBubbles;
    // BubbleScript Bubble_Script;
    // public Color blueCircuitField;
    // public Color redDanger;

    public string playerNumber;
    public string connectKey;
    public string activateKey;
    public string disconnectKey;
    public string special;

    public string connectMessage;
    public string activateController;
    public string specialController;

    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("GearPlayerNumber");
        getControls();
     }
    

    void Start()
    {
        GearMove_Script = Gears.GetComponent<GearMove>();
        connectPos = new Vector3(-0.01f, 0.005f, -0.003f);
        // Bubble_Script = ActionBubbles.GetComponent<BubbleScript>();
        // redDanger = new Color(1f, 0.1f, 0.0f, 1.0f);
        
    }

    public void getControls()
    {
        if(playerNumber == "P1")
        {
            activateKey = "v";
            disconnectKey = "b";
            connectKey = "c";
            special = "space";
            activateController = "activate1";
            specialController = "special1";
        }
        else if(playerNumber == "P2")
        {
            activateKey = "k";
            disconnectKey = "l";
            connectKey = "j";
            special = "return";
            activateController = "activate2";
            specialController = "special2";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Gear") || other.name.Contains("BatteryUI"))
        {
            touching = other.gameObject;
            // touching.SendMessage("toggleBotTouching");
        }
            
    }

    void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("Gear") || other.name.Contains("BatteryUI"))
        {
             touching = other.gameObject;
             // touching.sendmessage("bot_touching");
        }
    }

     void OnTriggerExit(Collider other)
     {

            touching = null;
            // touching.SendMessage("toggleBotTouching");
            // Bubble_Script.actionBubbleStop();
            // Light_Script.actionBubbleStop();
            // Circle_Script.actionBubbleStop();

     }

     void Update()
     {
        // if(touching != null && Input.GetKeyDown(connectKey))
        // {
        //     Connect();
        // }
        // if(touching != null && Input.GetKeyDown(disconnectKey))
        // {
        //     Disconnect();
        // }

        if(touching != null && Input.GetKeyDown(activateKey))
        {
            Activate();
        }
        if(connected && Input.GetKeyDown(special))
        {
            touching.SendMessage("Activate", ErrorMessage);
        }
        if(touching != null && Input.GetButtonDown(activateController))
        {
            Activate();
        }
        if(connected && Input.GetButtonDown(specialController))
        {
            touching.SendMessage("Activate", ErrorMessage);
        }
     }

     public void Activate()
     {
          GearMove_Script.Activate();
         
        if(touching.name.Contains("Claw") || touching.name.Contains("Crawlers") || touching.name.Contains("Rotator"))
        {
            var connectMessage = connected ? "disconnect" : "connect";
            connected = !connected; 
            if(connected)
            {
                Gears.gameObject.AddComponent<FixedJoint>();
                Gears.gameObject.GetComponent<FixedJoint>().connectedBody=touching.GetComponent<Rigidbody>();
            }
            else if(!connected)
            {
                Destroy(Gears.gameObject.GetComponent<FixedJoint>());
            }
            GearMove_Script.toggleFixPosition();
            touching.SendMessage("toggleBotConnected");
            touching.SendMessage(connectMessage);
        }   
        else touching.SendMessage("Activate", ErrorMessage);
            
     }
    
}