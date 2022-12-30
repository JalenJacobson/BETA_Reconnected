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
    public int BotControlling_Index;

    public Vector2 moveInputValue;

    public float x;
    public float y;
    
    
        void Awake()
     {
        PlayerToggle = GameObject.Find("PlayerToggle");
        PlayerToggle_Script = PlayerToggle.GetComponent<PlayerToggle>();
     }
    
    void Start()
    {
        // BotControllingIndex should come from character select as a player prefs
        getNewBot();

    }

    public void getNewBot()
    {
        BotControlling = PlayerToggle_Script.bots[0];
        BotControlling_Script = PlayerToggle_Script.moveScripts[0];
        TriggerCube_Script = PlayerToggle_Script.triggerScripts[0];
    }

    private void OnMove(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
        print("GAMER" + Gamepad.current.displayName);
        x = moveInputValue.x;
        y = moveInputValue.y;
    }

    public void FixedUpdate()
    {
        BotControlling_Script.Movement(x, y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
