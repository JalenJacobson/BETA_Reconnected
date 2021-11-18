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

    public GameObject ActionBubbles;
    BubbleScript Bubble_Script;
    public GameObject ActionLight;
    BubbleScript Light_Script;
    public GameObject ActionCircles;
    BubbleScript Circle_Script;
    public GameObject Activate1;
    Act1Script Act1Button_Script;
    public GameObject Cancel;
    CancelButton CancelButton_Script;

    public Color orangeGravityField;
    public Color greenConsole;
    public Color blueCircuitField;
    public Color redDanger;

    public string playerNumber;
    public string connectKey;
    public string activateKey;
    public string disconnectKey;
    public string special;

    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("GearPlayerNumber");
        getControls();
     }
    

    void Start()
    {
        GearMove_Script = Gears.GetComponent<GearMove>();
        connectPos = new Vector3(-0.01f, 0.005f, -0.003f);
        Bubble_Script = ActionBubbles.GetComponent<BubbleScript>();
        Light_Script = ActionLight.GetComponent<BubbleScript>();
        Circle_Script = ActionCircles.GetComponent<BubbleScript>();
        Act1Button_Script = Activate1.GetComponent<Act1Script>();
        CancelButton_Script = Cancel.GetComponent<CancelButton>();
        redDanger = new Color(1f, 0.1f, 0.0f, 1.0f);
        greenConsole = new Color(0.0f, 1.0f, 0.1144f, 1.0f);
        
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
    if(other.name.Contains("Gear")){
            Bubble_Script.actionBubbleStart();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart();

        }

     }

    void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("Gear")){
             touching = other.gameObject;
        }
    }

     void OnTriggerExit(Collider other)
     {
        if(other.name.Contains("Gear"))
        {
            touching = null;
            // Bubble_Script.actionBubbleStop();
            // Light_Script.actionBubbleStop();
            // Circle_Script.actionBubbleStop();
        }
     }

     void Update()
     {
         if(touching != null && Input.GetKeyDown(connectKey))
         {
             Connect();
         }
         if(touching != null && Input.GetKeyDown(disconnectKey))
         {
             Disconnect();
         }

         if(connected == true && Input.GetKeyDown(activateKey))
         {
             Activate();
         }
     }

     public void Activate()
     {
        touching.SendMessage("Activate", ErrorMessage);
            
     }
     public void Deactivate()
     {
         touching.SendMessage("Deactivate", ErrorMessage);
     }

     public void Connect()
     {
            connected = true; 
            Gears.transform.position = touching.transform.TransformPoint(connectPos);
            GearMove_Script.toggleFixPosition();
            // Bubble_Script.actionBubbleStop();
            // Act1Button_Script.activate1();
            // Connection.text = touching.name.ToString(); 
            // CancelButton_Script.CancelStart(); 
            print(touching.name);
            if(touching.name.Contains("Claw"))
            {
                print("CONNECTED To Claw");
                touching.SendMessage("ClawConnected");
            }   
            
     }
     
     public void Disconnect()
     {
            connected = false;  
            GearMove_Script.toggleFixPosition();
            // Light_Script.actionBubbleStop();
            // Circle_Script.actionBubbleStop();
            // Act1Button_Script.activate1Stop();
            // Connection.text= "F";
            // resetConsoleMessage();
            // CancelButton_Script.CancelStop();  
            if(touching.name.Contains("Claw"))
            {
                print("CONNECTED To Claw");
                touching.SendMessage("ClawDisonnected");
            }   
     }

     public void resetConsoleMessage()
     {
         ErrorMessage.text = "";
         ErrorMessage.color = greenConsole;
     }
}