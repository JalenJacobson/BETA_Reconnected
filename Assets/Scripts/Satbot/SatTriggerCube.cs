using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatTriggerCube : TriggerCubeBase
{
    public GameObject SatBot;
    SatMove SatMove_Script;

    public bool triggerEntered = false;
    public GameObject touching = null;
    public string touchingToken;
    public bool connected = false;
    public Vector3 connectPos;
    public string token;
    public GameObject[] SatHelp_Icons;
    public GravaRotator GravaRotator_Script = null;

    public Vector2 moveInputValues;

    
    
    public bool tokenExpire = false;
    public float tokenExpireTime;


    // public GameObject TimerBarSat;
    // TimeBarSat TimerBarSat_Script;

    // public string playerNumber;
    // public string connectKey;
    // public string activateKey;
    // public string disconnectKey;
    // public string special;
    // public string activateController;
    // public string specialController;

    // public int controllingPlayer = 0;

    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("SatPlayerNumber");
        
     }

    void Start()
    {
        SatMove_Script = SatBot.GetComponent<SatMove>();
        SatHelp_Icons = GameObject.FindGameObjectsWithTag("SatHelpIcon");
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
         if(other.name.Contains("Sat")){
             touching = other.gameObject;
             touching.SendMessage("toggleBotTouching");
             if(other.name.Contains("Upload"))
             {
                 touchingToken = touching.GetComponent<Sat_Upload_1>().token;
             }
        }
        else if(other.name.Contains("BatteryUI"))
        {
            touching = other.gameObject;
        }

    }

    void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("Sat")){
             touching = other.gameObject;
             if(other.name.Contains("Upload"))
             {
                 touchingToken = touching.GetComponent<Sat_Upload_1>().token;
             }
        }
        else if(other.name.Contains("BatteryUI"))
        {
            touching = other.gameObject;
        }
    }

     void OnTriggerExit(Collider other)
     {
        // touching.SendMessage("toggleBotBoth");
        
        if(other.name.Contains("Sat"))
        {
            touching = null;
            touchingToken = null;
        }
        else if(other.name.Contains("BatteryUI"))
        {
            touching = null;
        }
     }

      void Update()
     {
        if(tokenExpire)
        {
            if(tokenExpireTime > 0)
            {
                tokenExpireTime -= Time.deltaTime;

            }
            else 
            {
                token = "0";
                tokenExpire = false;

            }      
        }
     }

     void FixedUpdate()
     {
        moveInputValues = SatMove_Script.moveInputValues;
        if(connected)
        {
            if(GravaRotator_Script != null)
            {
                GravaRotator_Script.Movement(moveInputValues.x, moveInputValues.y);
            }
            
        }
     }

    void DownloadToken()
    {
        var downloadTokenScript = touching.GetComponent<Sat_Download_1>();
        token = downloadTokenScript.token;
        print("download");
    }
    void DownloadExpiringToken()
    {
        var downloadTokenScript = touching.GetComponent<Sat_Download_2>();
        token = downloadTokenScript.token;
        tokenExpire = downloadTokenScript.tokenExpire;
        tokenExpireTime = downloadTokenScript.tokenExpireTime;

        print("downloaded expiring");
    }

    public override void Activate()
     {
        if(touching.name.Contains("Download"))
        {
            touching.SendMessage("Activate");
            if(touching.name.Contains("Expiring"))
            {
                DownloadExpiringToken();
                // ErrorMessage.text = "Expiring Token Downloaded";
            }
            else 
            {
                DownloadToken();
                // ErrorMessage.text = "Token Downloaded";
            }
        }
        else if(touching.name.Contains("Upload"))
        {
            if(token == touchingToken)
            {
                touching.SendMessage("Activate", "forceGate");
                token = "0";
                tokenExpire = false;
            }
        }
        else if(touching.name.Contains("Grava"))
        {
            var connectMessage = connected ? "disconnect" : "connect";
            connected = !connected; 
            if(connected)
            {
                SatBot.gameObject.AddComponent<FixedJoint>();
                SatBot.gameObject.GetComponent<FixedJoint>().connectedBody=touching.GetComponent<Rigidbody>();
                touching.SendMessage("setGravaInTriggerCube", gameObject.GetComponent<SatTriggerCube>());
            }
            else if(!connected)
            {
                Destroy(SatBot.gameObject.GetComponent<FixedJoint>());
                setGravaToNull();
            }
            SatMove_Script.connectGrava();
            
        }
        else touching.SendMessage("Activate");
             
     }

    void setGravaToNull()
    {
        GravaRotator_Script = null;
    }

     public override void Special()
     {
        SatMove_Script.controllingCamera = !SatMove_Script.controllingCamera;
     }

     public override void enableHelpIcon()
     {
        foreach(GameObject HelpIconCanvas in SatHelp_Icons)
        {
            HelpIconCanvas.GetComponent<Canvas> ().enabled = true;
        }
        //StartCoroutine(StartHelpIcon());
     }
     public override void enableHelpIconStop()
     {
        foreach(GameObject HelpIconCanvas in SatHelp_Icons)
        {
            HelpIconCanvas.GetComponent<Canvas> ().enabled = false;
        }
        //StartCoroutine(StartHelpIcon());
     }
     
     IEnumerator StartHelpIcon()
    {

        foreach(GameObject HelpIconCanvas in SatHelp_Icons)
        {
            HelpIconCanvas.GetComponent<Canvas> ().enabled = true;
        }
        yield return new WaitForSeconds(5f);
        foreach(GameObject HelpIconCanvas in SatHelp_Icons)
        {
            HelpIconCanvas.GetComponent<Canvas> ().enabled = false;
        }
               
    }
     
}
