using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCubeBase : MonoBehaviour
{

    public int controllingPlayer = 0;
    public string playerNumber;

    public string connectKey;
    public string activateKey;
    public string disconnectKey;
    public string special;
    public string activateController;
    public string specialController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Activate()
    {
        
    }
    public virtual void Special()
    {

    }

    public virtual void setCurrentPlayer(int player)
    {
        controllingPlayer = player;
        playerNumber = "P" + player.ToString();
        getControls();
    }

    public void getControls()
    {
        if(playerNumber == "P0") return;
        else if(playerNumber == "P1")
        {
            activateKey = "v";
            disconnectKey = "b";
            connectKey = "c";
            special = "space";
            activateController = "activate1";
            specialController = "special1";
        }
        else if(playerNumber == "P2")
        {
            activateKey = "k";
            disconnectKey = "l";
            connectKey = "j";
            special = "return";
            activateController = "activate2";
            specialController = "special2";
        }
    }
}
