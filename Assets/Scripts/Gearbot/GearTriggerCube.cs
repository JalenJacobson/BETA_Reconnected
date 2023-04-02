using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearTriggerCube : TriggerCubeBase
{
    public GameObject Gears;
    GearMove GearMove_Script;

    public Text Connection;
    public Text ErrorMessage;
    
    public bool triggerEntered = false;
    public bool connected = false;
    public bool connectedToWall = false;
    public GameObject touching = null;
    // public bool gearWall = false;
    public Vector3 connectPos;

    public Claw gizmoClaw_Script = null;
    public LazerFollow gizmoLazer_Script = null;
    public Rotator gizmoRotator_Script = null;
    public Gear_Crawler gizmoGear_Crawler_Script = null;

    public GameObject gearWall;
    public List<GameObject> touchingGearWalls;
    

    public Vector2 moveInputValues;
    public GameObject[] GearHelp_Icons;

    public string XorZ;
    public GameObject GearSpecial;

    // public int controllingPlayer = 0;

    // public GameObject ActionBubbles;
    // BubbleScript Bubble_Script;
    // public Color blueCircuitField;
    // public Color redDanger;

    // public string playerNumber;
    // public string connectKey;
    // public string activateKey;
    // public string disconnectKey;
    // public string special;

    // public string connectMessage;
    // public string activateController;
    // public string specialController;

    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("GearPlayerNumber");
        
     }
    

    void Start()
    {
        GearMove_Script = Gears.GetComponent<GearMove>();
        connectPos = new Vector3(-0.01f, 0.005f, -0.003f);
        GearHelp_Icons = GameObject.FindGameObjectsWithTag("GearHelpIcon");
        GearSpecial = GameObject.FindGameObjectWithTag("GearSpecialUI");
        // Bubble_Script = ActionBubbles.GetComponent<BubbleScript>();
        // redDanger = new Color(1f, 0.1f, 0.0f, 1.0f);
        //getControls();
    }

    // public void getControls()
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

    // public void setCurrentPlayer(int player)
    // {
    //     controllingPlayer = player;
    //     playerNumber = "P" + player.ToString();
    //     getControls();
    // }

    void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Gear") || other.name.Contains("BatteryUI"))
        {
            touching = other.gameObject;
            // touching.SendMessage("toggleBotTouching");
        }
        else if(other.name.Contains("Wall"))
        {
            touchingGearWalls.Add(other.gameObject);
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
        else if(other.name.Contains("Wall"))
        {
            if(connectedToWall == true)
            {
                GearMove_Script.OnWall();
            }
            // touching.SendMessage("toggleBotTouching");
        }
    }

     void OnTriggerExit(Collider other)
     {
            if(other.name.Contains("Wall"))
            {
                touchingGearWalls.Remove(other.gameObject);
                if(touchingGearWalls.Count <= 0 )
                {
                    wallInteraction(false);
                    GearMove_Script.OffWall();
                }
            }
            touching = null;
            // touching.SendMessage("toggleBotTouching");
            // Bubble_Script.actionBubbleStop();
            // Light_Script.actionBubbleStop();
            // Circle_Script.actionBubbleStop();

     }

    //  public void setGearWall(bool sendingGearWall)
    //  {
    //     if(gearWall == false)
    //     {
    //         gearWall = sendingGearWall;
    //     }
    //  }

     void FixedUpdate()
     {
        if(connected)
        {
            moveInputValues = GearMove_Script.moveInputValues;
            if(gizmoClaw_Script != null)
            {
                gizmoClaw_Script.Movement(moveInputValues.x, moveInputValues.y);
            }
            if(gizmoLazer_Script != null)
            {
                gizmoLazer_Script.Movement(moveInputValues.x, moveInputValues.y);
            }
            else if(gizmoRotator_Script != null)
            {
                gizmoRotator_Script.Movement(moveInputValues.x, moveInputValues.y);
            }
            if(gizmoGear_Crawler_Script != null)
            {
                gizmoGear_Crawler_Script.Movement(moveInputValues.x, moveInputValues.y);
            }
            
            
        }
     }

     public override void Special()
     {
        print("CALL SPECIAL");
        if(gizmoClaw_Script != null)
        {
            gizmoClaw_Script.Activate();
        }
     }
     

    void Update()
    {
        if(Input.GetKeyDown("b"))
        {
            Activate();
        }
    }

     public override void Activate()
     {
        if(connectedToWall)
        {
            wallInteraction(false);
        }
        if(!touching) return;
          GearMove_Script.Activate();
         
        if(touching.name.Contains("Claw") || touching.name.Contains("Crawlers") || touching.name.Contains("Rotator") || touching.name.Contains("Lazer"))
        {
            var connectMessage = connected ? "disconnect" : "connect";
            connected = !connected; 
            if(connected)
            {
                Gears.gameObject.AddComponent<FixedJoint>();
                Gears.gameObject.GetComponent<FixedJoint>().connectedBody=touching.GetComponent<Rigidbody>();
                touching.SendMessage("setGizmoInTriggerCube", gameObject.GetComponent<GearTriggerCube>());
                if(touching.name.Contains("Claw"))
                {
                    GearSpecial.GetComponent<Animator>().Play("GearSpecialClaw");
                }
                else if(touching.name.Contains("Crawlers") || touching.name.Contains("Rotator"))
                {
                    GearSpecial.GetComponent<Animator>().Play("GearSpecialGear");
                }
            }
            else if(!connected)
            {
                Destroy(Gears.gameObject.GetComponent<FixedJoint>());
                setGizmoToNull();
                GearSpecial.GetComponent<Animator>().Play("GearSpecial");
            }
            GearMove_Script.toggleFixPosition();
            GearMove_Script.Gizmo();
            
            touching.SendMessage("toggleBotConnected");
            touching.SendMessage(connectMessage);
        }   
        else if(touching.name.Contains("Wall"))
        {
            connectedToWall = !connectedToWall;
            wallInteraction(connectedToWall);
            touching.SendMessage("Activate");
            GearSpecial.GetComponent<Animator>().Play("GearSpecialGear");
        }
        else touching.SendMessage("Activate", ErrorMessage);
            
     }

    public void wallInteraction(bool shouldConnect)
    {
        if(touching != null)
        {
            if(touching.name.Contains("Z"))
            {
                XorZ = "z";
            }
            else XorZ = "x";
        }
        GearMove_Script.connectToWall(shouldConnect, XorZ);
        connectedToWall = shouldConnect;
    }

    public void setGizmoToNull()
    {
        gizmoClaw_Script = null;
        gizmoRotator_Script = null;
        gizmoGear_Crawler_Script = null;
    }

     public override void enableHelpIcon()
     {
        foreach(GameObject HelpIconCanvas in GearHelp_Icons)
        {
            HelpIconCanvas.GetComponent<Canvas> ().enabled = true;
        }
        //StartCoroutine(StartHelpIcon());
     }
     public override void enableHelpIconStop()
     {
        foreach(GameObject HelpIconCanvas in GearHelp_Icons)
        {
            HelpIconCanvas.GetComponent<Canvas> ().enabled = false;
        }
        //StartCoroutine(StartHelpIcon());
     }
     
     IEnumerator StartHelpIcon()
    {

        foreach(GameObject HelpIconCanvas in GearHelp_Icons)
        {
            HelpIconCanvas.GetComponent<Canvas> ().enabled = true;
        }
        yield return new WaitForSeconds(5f);
        foreach(GameObject HelpIconCanvas in GearHelp_Icons)
        {
            HelpIconCanvas.GetComponent<Canvas> ().enabled = false;
        }
               
    }
     
    
}