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
        touching = null;
        touchingToken = null;
        if(other.name.Contains("Sat"))
        {

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

        if(touching != null && Input.GetKeyDown(connectKey))
         {
             Connect();
         }
         if(touching != null && Input.GetKeyDown(disconnectKey))
         {
             Disconnect();
         }

         if(touching != null && Input.GetKeyDown(activateKey))
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

            }
        }
        // else if(touching.name.Contains("Portal")) 
        // {
        //     touching.SendMessage("Activate");
        // }
        // else if(touching.name.Contains("Doors"))
        // {
        //     touching.SendMessage("Activate");
        // }
        else touching.SendMessage("Activate");
             
     }

    public void Connect()
    {
        if(!connected)
        {
            connected = !connected;  
            SatMove_Script.toggleFixPosition();
            touching.SendMessage("toggleBotConnected");
        }
        else return;
    }
     
    public void Disconnect()
    {
        if(connected)
        {
            connected = false;  
            SatMove_Script.toggleFixPosition();
            touching.SendMessage("toggleBotConnected");
        }   
        else return; 
    }
}
