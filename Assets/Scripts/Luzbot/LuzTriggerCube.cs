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
         if(touching != null && Input.GetKeyDown("c"))
         {
             Connect();
            // Activate();
         }
         if(touching != null && Input.GetKeyDown("b"))
         {
             Disconnect();
         }

        //  if(connected == true)
        //  {
        //      GearMove_Script.fixPosition = true;
        //  }

         if(connected == true && Input.GetKeyDown("v"))
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
            connected = !connected;  
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
