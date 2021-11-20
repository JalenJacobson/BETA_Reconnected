using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuzTriggerCube : MonoBehaviour
{

    public GameObject IdleLuz;
    LuzMove LuzMove_Script;
    
    public bool triggerEntered = false;
    public bool connected = false;
    public Vector3 connectPos;
    public GameObject touching = null;

    public Text Connection;
    public Text ErrorMessage;

    public GameObject ActionPower;
    ActionPowerScript Bubble_Script;
    public GameObject ActionLight;
    ActionPowerScript Light_Script;
    public GameObject ActionCircles;
    ActionPowerScript Circle_Script;
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
        playerNumber = PlayerPrefs.GetString("LuzPlayerNumber");
        getControls();
     }

    void Start()
    {
        LuzMove_Script = IdleLuz.GetComponent<LuzMove>();
        Bubble_Script = ActionPower.GetComponent<ActionPowerScript>();
        Light_Script = ActionLight.GetComponent<ActionPowerScript>();
        Circle_Script = ActionCircles.GetComponent<ActionPowerScript>();
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
        if(other.name.Contains("luz") || other.name.Contains("Power"))
        {
            Bubble_Script.actionBubbleStart();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart();    
        }
     }

    void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("Luz") || other.name.Contains("Power")){
             touching = other.gameObject;
        }
    }

     void OnTriggerExit(Collider other)
     {
            touching = null;
        if(other.name.Contains("luz") || other.name.Contains("Power")){
             
            Bubble_Script.actionBubbleStop();
            Light_Script.actionBubbleStop();
            Circle_Script.actionBubbleStop();    
       }
     }

     void Update()
     {
         if(touching != null && Input.GetKeyDown(connectKey))
         {
             Connect();
            // Activate();
         }
         if(touching != null && Input.GetKeyDown(disconnectKey))
         {
             Disconnect();
         }

        //  if(connected == true)
        //  {
        //      GearMove_Script.fixPosition = true;
        //  }

         if(connected == true && Input.GetKeyDown(activateKey))
         {
             print("chould activate");
             Activate();
         }
     }

     public void Activate()
     {
             touching.SendMessage("Activate");
     }
     public void Deactivate()
     {
         touching.SendMessage("Deactivate", ErrorMessage);
     }

     public void Connect()
     {
            connected = true;  
            LuzMove_Script.restoreHealth();
            LuzMove_Script.toggleFixPosition();
            Bubble_Script.actionBubbleStop();
            Act1Button_Script.activate1();
            Connection.text = touching.name.ToString();
            CancelButton_Script.CancelStart();       
     }
     
     public void Disconnect()
     {
            connected = false;  
            LuzMove_Script.toggleFixPosition();
            Light_Script.actionBubbleStop();
            Circle_Script.actionBubbleStop();
            Act1Button_Script.activate1Stop();
            Connection.text = "T";
            resetConsoleMessage();
            CancelButton_Script.CancelStop();        
     }

     public void resetConsoleMessage()
     {
         ErrorMessage.text = "";
         ErrorMessage.color = greenConsole;
     }
}
