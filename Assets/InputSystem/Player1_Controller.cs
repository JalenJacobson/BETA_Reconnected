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
    
    public Player_Toggle_LevelSelect Player_Toggle_LevelSelect_Script;
    public GameObject BotControlling;
    public Player BotControlling_Script;
    public TriggerCubeBase TriggerCube_Script;
    public int availableBot;
    public GameObject oldBotControlling;
    public Player oldBotControlling_Script;
    public TriggerCubeBase oldTriggerCube_Script;
    public string startingBot;

    public bool firstInstantiation = true;
    

    public Vector2 moveInputValue;

    public float x;
    public float y;

    public PlayerToggle PlayerToggle_Script;
    public GameObject Player_Toggle_LevelSelect;
    public GameObject BotControlling_LevelSelect;
    public HeroSelectPlayer BotControlling_LevelSelect_Script;
    public GameObject oldBotControlling_LevelSelect;
    public HeroSelectPlayer oldBotControlling_LevelSelect_Script;
    public int levelSelect_Bot_Index;
    public MoveNode Node_Move_Script;
    
    
        void Awake()
     {

        GameObject[] playerControllers = GameObject.FindGameObjectsWithTag("PlayerController");

        if (playerControllers.Length > 6)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        // gameObject.SetActive(true);
     }

    public void getScripts()
    {
        PlayerToggle = GameObject.Find("PlayerToggle");
        PlayerToggle_Script = PlayerToggle.GetComponent<PlayerToggle>();
        PauseMenuUi = GameObject.Find("PauseGame");
        PauseMenu_Script = PauseMenuUi.GetComponent<PauseMenu>();
    }

    void OnEnable()
    {
        print("onEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        print("onEnable called");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        print("Onsceneloaded" + scene.name);
        print(mode);
        if(scene.name.Contains("Level"))
        {
            firstInstantiation = false;
            getScripts();
            // getNewBot();
        }
        else if(scene.name == "HackingRoom")
        {
            firstInstantiation = false;
            BotControlling = GameObject.Find("Node");
            Node_Move_Script = BotControlling.GetComponent<MoveNode>();
        }
        else if(scene.name == "Map_Select")
        {
            firstInstantiation = false;
            BotControlling = GameObject.Find("Node");
            Node_Move_Script = BotControlling.GetComponent<MoveNode>();
        }
    }
    
    void Start()
    {
        if(firstInstantiation)
        {
            Player_Toggle_LevelSelect = GameObject.Find("Player_Toggle_LevelSelect");
            Player_Toggle_LevelSelect_Script = Player_Toggle_LevelSelect.GetComponent<Player_Toggle_LevelSelect>();
            getLevelSelectBot();
           // firstInstantiation = false;
        }
    }

    public void getLevelSelectBot()
    {
        if(BotControlling_LevelSelect != null)
        {
            // BotControlling_LevelSelect_Script.ToggleCircleOff();
            oldBotControlling_LevelSelect = BotControlling_LevelSelect;
            oldBotControlling_LevelSelect_Script = BotControlling_LevelSelect_Script;
            BotControlling_LevelSelect = null;
            BotControlling_LevelSelect_Script = null;
            
        }
        availableBot = Player_Toggle_LevelSelect_Script.getAvailableBotIndex();
        levelSelect_Bot_Index = availableBot;
        BotControlling_LevelSelect = Player_Toggle_LevelSelect_Script.bots[availableBot];
        BotControlling_LevelSelect_Script = Player_Toggle_LevelSelect_Script.selectScripts[availableBot];
        startingBot = BotControlling_LevelSelect.name;
        
        BotControlling_LevelSelect_Script.available = false;
        // BotControlling_LevelSelect_Script.ToggleCircle();

        if(oldBotControlling_LevelSelect_Script)
        {
            oldBotControlling_LevelSelect_Script.available = true;
        }
        

        oldBotControlling_LevelSelect = null;
        
    }

    public void getLevelSelectBot_Next()
    {
        if(BotControlling_LevelSelect != null)
        {
            // BotControlling_LevelSelect_Script.ToggleCircleOff();
            oldBotControlling_LevelSelect = BotControlling_LevelSelect;
            oldBotControlling_LevelSelect_Script = BotControlling_LevelSelect_Script;
            BotControlling_LevelSelect = null;
            BotControlling_LevelSelect_Script = null;
            
        }
        availableBot = Player_Toggle_LevelSelect_Script.getNextAvailableBotIndex(levelSelect_Bot_Index);
        // if(availableBot == -1) return;
        levelSelect_Bot_Index = availableBot;
        BotControlling_LevelSelect = Player_Toggle_LevelSelect_Script.bots[availableBot];
        BotControlling_LevelSelect_Script = Player_Toggle_LevelSelect_Script.selectScripts[availableBot];
        startingBot = BotControlling_LevelSelect.name;
        
        BotControlling_LevelSelect_Script.available = false;
        // BotControlling_LevelSelect_Script.ToggleCircle();
    
        oldBotControlling_LevelSelect_Script.available = true;

        oldBotControlling_LevelSelect = null;
        
    }
    public void getLevelSelectBot_Previous()
    {
        if(BotControlling_LevelSelect != null)
        {
            // BotControlling_LevelSelect_Script.ToggleCircleOff();
            oldBotControlling_LevelSelect = BotControlling_LevelSelect;
            oldBotControlling_LevelSelect_Script = BotControlling_LevelSelect_Script;
            BotControlling_LevelSelect = null;
            BotControlling_LevelSelect_Script = null;
            
        }
        availableBot = Player_Toggle_LevelSelect_Script.getPreviousAvailableBotIndex(levelSelect_Bot_Index);
        // if(availableBot == -1) return;
        levelSelect_Bot_Index = availableBot;
        BotControlling_LevelSelect = Player_Toggle_LevelSelect_Script.bots[availableBot];
        BotControlling_LevelSelect_Script = Player_Toggle_LevelSelect_Script.selectScripts[availableBot];
        startingBot = BotControlling_LevelSelect.name;
        
        BotControlling_LevelSelect_Script.available = false;
        // BotControlling_LevelSelect_Script.ToggleCircle();
    
        oldBotControlling_LevelSelect_Script.available = true;

        oldBotControlling_LevelSelect = null;
        
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

        if(firstInstantiation)
        {
            if(x >= .95)
            {
                getLevelSelectBot_Next();
            }
            else if(x <= -.95)
            {
                getLevelSelectBot_Previous();
            }
        }
        else if(!firstInstantiation)
        {
            if(BotControlling_Script != null) BotControlling_Script.Movement(x, y);
            if(Node_Move_Script != null)  Node_Move_Script.Movement(x, y);
        }
        
        
    }

    private void OnChangeRight()
    {
        getLevelSelectBot_Next();
    }

    private void OnChangeLeft()
    {
        getLevelSelectBot_Previous();
    }

    private void OnSubmit()
    {
       if(TriggerCube_Script != null) TriggerCube_Script.Activate();
       if(Node_Move_Script != null)  Node_Move_Script.Submit();
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
        if(Input.GetKeyDown("q"))
        {
            getLevelSelectBot_Next();
        }
        if(Input.GetKeyDown("w"))
        {
            getLevelSelectBot_Previous();
        }
    }

    
}
