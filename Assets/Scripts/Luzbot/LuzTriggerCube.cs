using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuzTriggerCube : TriggerCubeBase
{

    public GameObject IdleLuz;
    LuzMove LuzMove_Script;
    
    ActivatePower PowerScript;
    
    public bool triggerEntered = false;
    public bool connected = false;
    public Vector3 connectPos;
    public GameObject touching = null;

    // public int controllingPlayer = 0;

    public Text Connection;
    public Text ErrorMessage;

    // public string playerNumber;
    // public string connectKey;
    // public string activateKey;
    // public string disconnectKey;
    // public string special;
    // public string activateController;
    // public string specialController;

    void Awake()
     {
        playerNumber = PlayerPrefs.GetString("LuzPlayerNumber");
        
     }

    void Start()
    {
        LuzMove_Script = IdleLuz.GetComponent<LuzMove>();
        PowerScript = IdleLuz.GetComponent<ActivatePower>();
        // getControls();
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

    void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("Luz") || other.name.Contains("Power") || other.name.Contains("BatteryUI")){
             touching = other.gameObject;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.name.Contains("Luz") || other.name.Contains("Power") || other.name.Contains("BatteryUI")){
             touching = null;
        }
    }

    void Update()
    {
        // if(touching != null && Input.GetKeyDown(activateKey))
        // {
        //     Activate();
        //     PowerScript.Play();
        // }
        // if(touching != null && Input.GetButtonDown(activateController))
        // {
        //     Activate();
        //     PowerScript.Play();
        // }
    }

    public override void Activate()
    {
        touching.SendMessage("Activate");
        PowerScript.Play();
    }
    
    public override void Special()
    {
        LuzMove_Script.Recharge();
    }
}
