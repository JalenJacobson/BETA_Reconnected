using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player1_Controller : MonoBehaviour
{
    public GameObject PauseMenuUi;
    public PauseMenu PauseMenu_Script;
    public GameObject PlayerToggle;
    public PlayerToggle PlayerToggle_Script;
    public GameObject BotControlling;
    public Player BotControlling_Script;
    public TriggerCubeBase TriggerCube_Script;
    public int availableBot;
    public GameObject oldBotControlling;
    public Player oldBotControlling_Script;
    public TriggerCubeBase oldTriggerCube_Script;

    

    public Vector2 moveInputValue;

    public float x;
    public float y;
    
    
        void Awake()
     {
        PlayerToggle = GameObject.Find("PlayerToggle");
        PlayerToggle_Script = PlayerToggle.GetComponent<PlayerToggle>();
        PauseMenuUi = GameObject.Find("PauseGame");
        PauseMenu_Script = PauseMenuUi.GetComponent<PauseMenu>();
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
            BotControlling_Script.ToggleCircleOff();
            oldBotControlling = BotControlling;
            oldBotControlling_Script = BotControlling_Script;
            oldTriggerCube_Script = TriggerCube_Script;
            BotControlling = null;
            BotControlling_Script = null;
            TriggerCube_Script = null;
        }
        availableBot = PlayerToggle_Script.getAvailableBotIndex();
        BotControlling = PlayerToggle_Script.bots[availableBot];
        BotControlling_Script = PlayerToggle_Script.moveScripts[availableBot];
        TriggerCube_Script = PlayerToggle_Script.triggerScripts[availableBot];
        PlayerToggle_Script.bots.Remove(BotControlling);
        PlayerToggle_Script.moveScripts.Remove(BotControlling_Script);
        PlayerToggle_Script.triggerScripts.Remove(TriggerCube_Script);
        BotControlling_Script.available = false;
        BotControlling_Script.ToggleCircle();
    
        oldBotControlling_Script.available = true;
        PlayerToggle_Script.bots.Add(oldBotControlling);
        PlayerToggle_Script.moveScripts.Add(oldBotControlling_Script);
        PlayerToggle_Script.triggerScripts.Add(oldTriggerCube_Script);
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

    private void OnSubmit()
    {
        TriggerCube_Script.Activate();
    }

    private void OnSpecial()
    {
        TriggerCube_Script.Special();
    }

     private void OnToggle()
     {
        print("TOGGLING WORKED");
        getNewBot();
     }

     private void OnPause()
    {
        PauseMenu_Script.PlayerPause();
    }

    public void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
