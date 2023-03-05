using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpTriggerCube : TriggerCubeBase
{
    public GameObject Pump;
    PumpMove PumpMove_Script;
    public GameObject Connector;
    public PumpConnector ConnectionScript;
    
    public bool connected = false;
    public Vector3 connectPos;
    public GameObject touching = null;
    public Animator anim;
    public GameObject BlueWall;
    BlueWall BlueWall_Script;
    public bool connectedBox = false;
    public GameObject connectedBoxName = null;
    public GameObject[] PumpHelp_Icons;
    public GameObject PumpUI;
    public Animator animUI;
    public GameObject PumpSpecial;


    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("PumpPlayerNumber");
        
     }

    void Start()
    {
        ConnectionScript = Connector.GetComponent<PumpConnector>();
        PumpMove_Script = Pump.GetComponent<PumpMove>();
        BlueWall_Script = BlueWall.GetComponent<BlueWall>();
        anim = GetComponent<Animator>();
        PumpHelp_Icons = GameObject.FindGameObjectsWithTag("PumpHelpIcon");
        animUI = PumpUI.GetComponent<Animator>();
        PumpSpecial = GameObject.FindGameObjectWithTag("PumpSpecialUI");

    }



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
            ConnectionScript.touching = null;
        }

     }

     void Update()
     {
    
     }

     public override void Activate()
     {
        if(touching)
        {
            if(touching.name.Contains("ConnectionBox") && !connectedBox)
            {
                ConnectionScript.SendMessage("Connect");
                connectedBoxName = touching;
                animUI.Play("UiButton");
                if(touching.name.Contains("Drain"))
                {
                    PumpSpecial.GetComponent<Animator>().Play("PumpSpecialDrain");
                }
                else if(touching.name.Contains("Fire"))
                {
                    PumpSpecial.GetComponent<Animator>().Play("PumpSpecialFire");
                }
                else if(touching.name.Contains("Air"))
                {
                    PumpSpecial.GetComponent<Animator>().Play("PumpSpecialAir");
                }
            }
            else touching.SendMessage("Activate");
        }
        else if(touching == null && connectedBox)
        {
           SnapBack();
           PumpSpecial.GetComponent<Animator>().Play("PumpSpecial");
        }
        
     }

    public override void Special()
    {
        PumpMove_Script.openBubble();
        if(connectedBoxName)
        {
            if(connectedBoxName.name.Contains("Drain"))
            {      
                if(touching.name.Contains("Drainage")) 
                {
                    touching.SendMessage("waterDrain");
                    PumpMove_Script.waterDrain();
                }    
            }
            else if(connectedBoxName.name.Contains("Air"))
            {
                PumpMove_Script.pumpBlow();
            }
            else if(connectedBoxName.name.Contains("Fire"))
            {
                PumpMove_Script.pumpBurn();
            }
            else if(connectedBoxName.name.Contains("Gas"))
            {
                // Gas animation
            }
        }
     }

     public void SnapBack()
     {
       ConnectionScript.SendMessage("SnapHoseBack");
       animUI.Play("UiButtonDown");  
     }

       public override void enableHelpIcon()
     {
        foreach(GameObject HelpIconCanvas in PumpHelp_Icons)
        {
            HelpIconCanvas.GetComponent<Canvas> ().enabled = true;
        }
        //StartCoroutine(StartHelpIcon());
     }
     public override void enableHelpIconStop()
     {
        foreach(GameObject HelpIconCanvas in PumpHelp_Icons)
        {
            HelpIconCanvas.GetComponent<Canvas> ().enabled = false;
        }
        //StartCoroutine(StartHelpIcon());
     }
     
     IEnumerator StartHelpIcon()
    {

        foreach(GameObject HelpIconCanvas in PumpHelp_Icons)
        {
            HelpIconCanvas.GetComponent<Canvas> ().enabled = true;
        }
        yield return new WaitForSeconds(5f);
        foreach(GameObject HelpIconCanvas in PumpHelp_Icons)
        {
            HelpIconCanvas.GetComponent<Canvas> ().enabled = false;
        }
               
    }
}
