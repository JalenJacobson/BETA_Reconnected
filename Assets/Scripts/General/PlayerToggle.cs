using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToggle : MonoBehaviour
{

    public GameObject[] botsInitial;
    public List<GameObject> bots;
    public List<Player> moveScripts;
    public List<TriggerCubeBase> triggerScripts;

    public int player1;
    public int player2;
    
    void Awake()
    {
        botsInitial = GameObject.FindGameObjectsWithTag("Bot");
        foreach (GameObject botInitial in botsInitial)
        {
            bots.Add(botInitial);
        }
        foreach (GameObject botInitial in botsInitial)
        {
            moveScripts.Add(botInitial.GetComponent<Player>());
        }
        foreach (GameObject botInitial in botsInitial)
        {
            Transform parentTrans = botInitial.transform;
            Transform childTrans = parentTrans.Find("TriggerCube");
            GameObject triggerCube = childTrans.gameObject;
            TriggerCubeBase triggerCubeScript = triggerCube.GetComponent<TriggerCubeBase>();
            triggerScripts.Add(triggerCubeScript);
        }
        print(moveScripts[0]);
        selectStartingBots();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("g"))
        {
            togglePlayer1();
        }
        else if(Input.GetKeyDown("h"))
        {
            togglePlayer2();
        }

    }

    public void selectStartingBots()
    {
        //at some point this will take the starting bots from a player select screen. for now it will just start with brute and luz;
        player1 = 1;
        player2 = 0;
        resetAllPrefs();
        PlayerPrefs.SetString("BrutePlayerNumber", "P1");
        PlayerPrefs.SetString("LuzPlayerNumber", "P2");
        moveScripts[player1].controllingPlayer = 1;
        moveScripts[player2].controllingPlayer = 2;
    }

    public void resetAllPrefs()
    {
        PlayerPrefs.SetString("GearPlayerNumber", "P0");
        PlayerPrefs.SetString("LuzPlayerNumber", "P0");
        PlayerPrefs.SetString("BrutePlayerNumber", "P0");
        PlayerPrefs.SetString("PumpPlayerNumber", "P0");
        PlayerPrefs.SetString("SatPlayerNumber", "P0");
    }

    public void togglePlayer1()
    {
        moveScripts[player1].controllingPlayer = 0;
        checkAndSelectPlayer1();
    }

    public void checkAndSelectPlayer1()
    {
        print("AAAXXX" + moveScripts.Count);
        print(player1);
        if (player1 < moveScripts.Count - 1)
        {
            player1++;
        }
        else if (player1 == moveScripts.Count - 1)
        {
            player1 = 0;
        }
        
        if(moveScripts[player1].controllingPlayer == 0)
        {
           moveScripts[player1].setCurrentPlayer(1); 
           triggerScripts[player1].setCurrentPlayer(1); 
           return;
        }
        else if (moveScripts[player1].controllingPlayer != 0)
        {
            
            checkAndSelectPlayer1();
        }

    }

    public void togglePlayer2()
    {
        moveScripts[player2].controllingPlayer = 0;
        checkAndSelectPlayer2();
    }

    public void checkAndSelectPlayer2()
    {
        print("AAAXXX" + moveScripts.Count);
        print(player2);
        if (player2 < moveScripts.Count - 1)
        {
            player2++;
        }
        else if (player2 == moveScripts.Count - 1)
        {
            player2 = 0;
        }
        
        if(moveScripts[player2].controllingPlayer == 0)
        {
           moveScripts[player2].setCurrentPlayer(2); 
           triggerScripts[player2].setCurrentPlayer(2); 
           return;
        }
        else if (moveScripts[player2].controllingPlayer != 0)
        {
            
            checkAndSelectPlayer2();
        }

    }
}
