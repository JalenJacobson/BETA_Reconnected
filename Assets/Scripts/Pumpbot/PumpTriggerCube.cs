﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpTriggerCube : MonoBehaviour
{
    public GameObject Pump;
    PumpMove PumpMove_Script;
    public GameObject Connector;
    public PumpConnector ConnectionScript;
    
    public bool connected = false;
    public Vector3 connectPos;
    public GameObject touching = null;
    public Animator anim;
    // public GameObject ActionPump;
    // ActionPump Bubble_Script;
    // public GameObject ActionPump2;
    // ActionPump2 Bubble_Script2;
    // public GameObject ActionLight;
    // ActionPump Light_Script;
    // public GameObject ActionCircles;
    // ActionPump Circle_Script;
    // public GameObject Activate1Pump;
    // Act1Script Act1Button_Script;
    // public GameObject Activate2;
    // Act1Script Act2Button_Script;
    // public GameObject Activate3;
    // Act1Script Act3Button_Script;
    // public GameObject Cancel;
    // CancelButton CancelButton_Script;
    // public GameObject Cancel2;
    // CancelButton CancelButton2_Script;
    public GameObject BlueWall;
    BlueWall BlueWall_Script;

    public string playerNumber;
    public string connectKey;
    public string activateKey;
    public string disconnectKey;
    public string special;
    public string activateController;
    public string specialController;
    public bool connectedBox = false;

    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("PumpPlayerNumber");
        getControls();
     }


    // Start is called before the first frame update
    void Start()
    {
        ConnectionScript = Connector.GetComponent<PumpConnector>();
        PumpMove_Script = Pump.GetComponent<PumpMove>();
        // Bubble_Script = ActionPump.GetComponent<ActionPump>();
        // Bubble_Script2 = ActionPump2.GetComponent<ActionPump2>();
        // Light_Script = ActionLight.GetComponent<ActionPump>();
        // Circle_Script = ActionCircles.GetComponent<ActionPump>();
        // Act1Button_Script = Activate1Pump.GetComponent<Act1Script>();
        // Act2Button_Script = Activate2.GetComponent<Act1Script>();
        // Act3Button_Script = Activate3.GetComponent<Act1Script>();
        // CancelButton_Script = Cancel.GetComponent<CancelButton>();
        // CancelButton2_Script = Cancel2.GetComponent<CancelButton>();
        BlueWall_Script = BlueWall.GetComponent<BlueWall>();
        anim = GetComponent<Animator>();
    }

    public void getControls()
    {
        if(playerNumber == "P1")
        {
            activateKey = "v";
            // disconnectKey = "b";
            // connectKey = "c";
            special = "space";
            activateController = "activate1";
            specialController = "special1";
        }
        else if(playerNumber == "P2")
        {
            activateKey = "k";
            // disconnectKey = "l";
            // connectKey = "j";
            special = "return";
            activateController = "activate2";
            specialController = "special2";
        }
    }

//    void OnTriggerEnter(Collider other)
//      {
//         if(other.name.Contains("Water"))
//         {
//             Bubble_Script.actionBubbleStart();
//             Light_Script.actionBubbleStart();
//             Circle_Script.actionBubbleStart();
//         }
//         if(other.name.Contains("Pump") || (other.name.Contains("Gas")))
//         {
//             Bubble_Script2.actionBubble2Start();
//             Light_Script.actionBubbleStart();
//             Circle_Script.actionBubbleStart();
//         }

//      }

    void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("Pump") || other.name.Contains("Gas") || other.name.Contains("BatteryUI"))
        {
             touching = other.gameObject;
        }
        if(other.name.Contains("ConnectionBox"))
        {
             touching = other.gameObject;
             ConnectionScript.touching = other.gameObject;
        }
        if(other.name.Contains("Drain"))
        {
           touching = other.gameObject; 
        }
    }

     void OnTriggerExit(Collider other)
     {
        touching = null;
        if(other.name.Contains("pump") || other.name.Contains("Gas") || other.name.Contains("BatteryUI"))
        {
            touching = null;
            // Bubble_Script.actionBubbleStop();
            // Light_Script.actionBubbleStop();
            // Circle_Script.actionBubbleStop();
            // BlueWall_Script.Stop();
            // PumpMove_Script.BlueWallClose();
            // CancelButton_Script.CancelStop();
            // Bubble_Script2.actionBubble2Stop();
            ConnectionScript.touching = null;
        }

     }

     void Update()
     {
        //  if(touching != null && Input.GetKeyDown(connectKey))
        //  {
        //      Connect();
        //  }
        //  if(touching != null && Input.GetKeyDown(disconnectKey))
        //  {
        //      Disconnect();
        //  }
         if(touching != null && Input.GetKeyDown(activateKey))
         {
             Activate();
         }
         if(touching != null && connectedBox == true && Input.GetKeyDown(special))
         {
             pumpSpecial();
         }
        if(touching == null && connectedBox == true && Input.GetKeyDown(special))
         {
             pumpBlow();
         }
        if(touching != null && Input.GetButtonDown(activateController))
        {
            Activate();
        }
        if(touching == null && Input.GetKeyDown(activateKey))
        {
            SnapBack();   
        }
        if(touching == null && Input.GetButtonDown(activateController))
        {
            SnapBack();   
        }
     }

    //      public void Reactivate()
    //  {
    //         Bubble_Script.actionBubbleStart();
    //         Light_Script.actionBubbleStart();
    //         Circle_Script.actionBubbleStart();
    //  }
     public void Activate()
     {
             touching.SendMessage("Activate");
             ConnectionScript.SendMessage("Connect");

     }
    public void pumpSpecial()
     {
            if(touching.name.Contains("Drainage"))
            {         
             touching.SendMessage("waterDrain");
             PumpMove_Script.waterDrain();
            }
     }
    public void pumpBlow()
     {
             PumpMove_Script.pumpBlow();
     }

     public void SnapBack()
     {
       ConnectionScript.SendMessage("SnapHoseBack");  
     }
    // public void Activatefire()
    //  {
    //          touching.SendMessage("Activate2");
    //  }
    // public void Deactivatefire()
    //  {
    //          touching.SendMessage("Activate3");
    //  }

    // public void Connect()
    // {
    //     if(!connected)
    //     {
    //          connected = true;  
    //         PumpMove_Script.toggleFixPosition();
    //     }
       
    // }
     
    // public void Disconnect()
    // {   
    //     if(connected)
    //     {
    //         connected = false;  
    //         PumpMove_Script.toggleFixPosition(); 
    //     }
    //     else return;  
    // }
}
