using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1_Controller : MonoBehaviour
{
    public GameObject PlayerToggle;
    public PlayerToggle PlayerToggle_Script;
    public GameObject BotControlling;
    public Player BotControlling_Script;
    public TriggerCubeBase TriggerCube_Script;
    public int availableBot;
    public Player oldBotControlling;

    public Vector2 moveInputValue;

    public float x;
    public float y;
    
    
        void Awake()
     {
        PlayerToggle = GameObject.Find("PlayerToggle");
        PlayerToggle_Script = PlayerToggle.GetComponent<PlayerToggle>();
        getNewBot();
     }
    
    void Start()
    {
        // BotControllingIndex should come from character select as a player prefs
        

    }

    public void getNewBot()
    {
        if(BotControlling != null)
        {
            oldBotControlling = BotControlling_Script;
            BotControlling = null;
            BotControlling_Script = null;
            TriggerCube_Script = null;
        }
        availableBot = PlayerToggle_Script.getAvailableBotIndex();
        BotControlling = PlayerToggle_Script.bots[availableBot];
        BotControlling_Script = PlayerToggle_Script.moveScripts[availableBot];
        TriggerCube_Script = PlayerToggle_Script.triggerScripts[availableBot];
        BotControlling_Script.available = false;
        oldBotControlling.available = true;
        oldBotControlling = null;
    }

    private void OnMove(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
        print("GAMER" + Gamepad.current.displayName);
        x = moveInputValue.x;
        y = moveInputValue.y;
        BotControlling_Script.Movement(x, y);
    }

     private void OnToggle()
     {
        print("TOGGLING WORKED");
        getNewBot();
     }

    public void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
