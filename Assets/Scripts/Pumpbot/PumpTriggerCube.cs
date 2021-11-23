using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpTriggerCube : MonoBehaviour
{
    public GameObject Pump;
    PumpMove PumpMove_Script;
    
    public bool connected = false;
    public Vector3 connectPos;
    public GameObject touching = null;
    public Animator anim;
    public GameObject ActionPump;
    ActionPump Bubble_Script;
    public GameObject ActionPump2;
    ActionPump2 Bubble_Script2;
    public GameObject ActionLight;
    ActionPump Light_Script;
    public GameObject ActionCircles;
    ActionPump Circle_Script;
    public GameObject Activate1Pump;
    Act1Script Act1Button_Script;
    public GameObject Activate2;
    Act1Script Act2Button_Script;
    public GameObject Activate3;
    Act1Script Act3Button_Script;
    public GameObject Cancel;
    CancelButton CancelButton_Script;
    public GameObject Cancel2;
    CancelButton CancelButton2_Script;
    public GameObject BlueWall;
    BlueWall BlueWall_Script;

    public string playerNumber;
    public string connectKey;
    public string activateKey;
    public string disconnectKey;
    public string special;

    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("PumpPlayerNumber");
        getControls();
     }


    // Start is called before the first frame update
    void Start()
    {
        PumpMove_Script = Pump.GetComponent<PumpMove>();
        Bubble_Script = ActionPump.GetComponent<ActionPump>();
        Bubble_Script2 = ActionPump2.GetComponent<ActionPump2>();
        Light_Script = ActionLight.GetComponent<ActionPump>();
        Circle_Script = ActionCircles.GetComponent<ActionPump>();
        Act1Button_Script = Activate1Pump.GetComponent<Act1Script>();
        Act2Button_Script = Activate2.GetComponent<Act1Script>();
        Act3Button_Script = Activate3.GetComponent<Act1Script>();
        CancelButton_Script = Cancel.GetComponent<CancelButton>();
        CancelButton2_Script = Cancel2.GetComponent<CancelButton>();
        BlueWall_Script = BlueWall.GetComponent<BlueWall>();
        anim = GetComponent<Animator>();
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
        if(other.name.Contains("Water"))
        {
            Bubble_Script.actionBubbleStart();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart();
        }
        if(other.name.Contains("Pump") || (other.name.Contains("Gas")))
        {
            Bubble_Script2.actionBubble2Start();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart();
        }

     }

    void OnTriggerStay(Collider other)
    {
        if((other.name.Contains("Pump")) || (other.name.Contains("Gas")))
        {
             touching = other.gameObject;
        }
    }

     void OnTriggerExit(Collider other)
     {
        touching = null;
        if((other.name.Contains("pump")) || (other.name.Contains("Gas")))
        {
            touching = null;
            Bubble_Script.actionBubbleStop();
            Light_Script.actionBubbleStop();
            Circle_Script.actionBubbleStop();
            // BlueWall_Script.Stop();
            // PumpMove_Script.BlueWallClose();
            CancelButton_Script.CancelStop();
            Bubble_Script2.actionBubble2Stop();
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

         public void Reactivate()
     {
            Bubble_Script.actionBubbleStart();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart();
     }
     public void Activate()
     {
             touching.SendMessage("Activate");
     }
    public void Activatefire()
     {
             touching.SendMessage("Activate2");
     }
    public void Deactivatefire()
     {
             touching.SendMessage("Activate3");
     }

    public void Connect()
    {
        if(!connected)
        {
             connected = true;  
            PumpMove_Script.toggleFixPosition();
        }
       
    }
     
    public void Disconnect()
    {   
        if(connected)
        {
            connected = false;  
            PumpMove_Script.toggleFixPosition(); 
        }
        else return;  
    }
}
