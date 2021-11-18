using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatTriggerCube : MonoBehaviour
{
    public GameObject SatBot;
    SatMove SatMove_Script;

    public bool triggerEntered = false;
    public GameObject touching = null;
    public string touchingToken;
    public bool connected = false;
    public Vector3 connectPos;
    public string token;
    
    public bool tokenExpire = false;
    public float tokenExpireTime;

    public Text Connection;
    public Text ErrorMessage;

    public GameObject ActionDownload;
    DownloadBubbleScript Bubble_Script;
    public GameObject ActionLight;
    DownloadBubbleScript Light_Script;
    public GameObject ActionCircles;
    DownloadBubbleScript Circle_Script;
    public GameObject Activate1;
    Act1Script Act1Button_Script;
    public GameObject Cancel;
    CancelButton CancelButton_Script;

    public Color orangeGravityField;
    public Color greenConsole;
    public Color blueCircuitField;
    public Color redDanger;
    
    // public GameObject TimerBarSat;
    // TimeBarSat TimerBarSat_Script;

    public string playerNumber;
    public string connectKey;
    public string activateKey;
    public string disconnectKey;
    public string special;

    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("SatPlayerNumber");
        getControls();
     }

    void Start(){
        SatMove_Script = SatBot.GetComponent<SatMove>();
        Bubble_Script = ActionDownload.GetComponent<DownloadBubbleScript>();
        Light_Script = ActionLight.GetComponent<DownloadBubbleScript>();
        Circle_Script = ActionCircles.GetComponent<DownloadBubbleScript>();
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
        if(other.name.Contains("Sat")){
             
            Bubble_Script.actionBubbleStart();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart();
             
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
    }

     void OnTriggerExit(Collider other)
     {
        touching = null;
        touchingToken = null;
        if(other.name.Contains("Sat"))
        {
            Bubble_Script.actionBubbleStop();
            Light_Script.actionBubbleStop();
            Circle_Script.actionBubbleStop();
        }
     }

      void Update()
     {
        if(tokenExpire)
        {
            if(tokenExpireTime > 0)
            {
                tokenExpireTime -= Time.deltaTime;
                ErrorMessage.text = "Token Expire in " + tokenExpireTime.ToString("0.00");
            }
            else 
            {
                token = "0";
                tokenExpire = false;
                ErrorMessage.text = "Token Expired";
            }      
        }

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

    public void Activate()
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
                if(touching.name.Contains("Endgame"))
                {
                    touching.SendMessage("Activate", "endGame");
                    token = "0";
                    // ErrorMessage.text = "Token Uploaded";
                    tokenExpire = false;
                }
                else
                {
                    touching.SendMessage("Activate", "forceGate");
                    token = "0";
                    // ErrorMessage.text = "Token Uploaded";
                    tokenExpire = false;
                }
            }
            else
            {
                ErrorMessage.text = "Activation Failed - Token Required";
                ErrorMessage.color = redDanger;
            }
        }
        else if(touching.name.Contains("Portal")) 
        {
            touching.SendMessage("Activate");
        }
        else if(touching.name.Contains("Doors"))
        {
            touching.SendMessage("Activate");
        }
             
     }

     public void Connect()
     {
        connected = !connected;  
        SatMove_Script.toggleFixPosition();
        Bubble_Script.actionBubbleStop();
        Act1Button_Script.activate1();
        Connection.text = touching.name.ToString();
        CancelButton_Script.CancelStart();     
     }
     
     public void Disconnect()
     {
             connected = false;  
             SatMove_Script.toggleFixPosition();
            Light_Script.actionBubbleStop();
            Circle_Script.actionBubbleStop();
            Act1Button_Script.activate1Stop();
            Connection.text = "F";
            resetConsoleMessage();
            CancelButton_Script.CancelStop();      
     }

     public void resetConsoleMessage()
     {
         ErrorMessage.text = "";
         ErrorMessage.color = greenConsole;
     }
}
