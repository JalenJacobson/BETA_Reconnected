using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToggle : MonoBehaviour
{

    public GameObject[] botsInitial;
    public List<GameObject> sortedBots;
    public List<GameObject> bots;
    public List<Player> moveScripts;
    public List<TriggerCubeBase> triggerScripts;
    

    public int player1;
    public int player2;
    
    void Awake()
    {
        botsInitial = GameObject.FindGameObjectsWithTag("Bot");
        // botsInitial = Array.Sort(botsInitial, (a,b) => a.name.CompareTo(b.name));
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

    }


    public void selectStartingBots()
    {
        //at some point this will take the starting bots from a player select screen. for now it will just start with brute and luz;
        player1 = 1;
        player2 = 0;
        // resetAllPrefs();
        // PlayerPrefs.SetString("BrutePlayerNumber", "P1");
        // PlayerPrefs.SetString("LuzPlayerNumber", "P2");
        // moveScripts[player1].controllingPlayer = 1;
        // moveScripts[player2].controllingPlayer = 2;

        moveScripts[player1].setCurrentPlayer(1);
        triggerScripts[player1].setCurrentPlayer(1);
        moveScripts[player2].setCurrentPlayer(2);
        triggerScripts[player2].setCurrentPlayer(2);
    }

    public void resetAllPrefs()
    {
        PlayerPrefs.SetString("GearPlayerNumber", "P0");
        PlayerPrefs.SetString("LuzPlayerNumber", "P0");
        PlayerPrefs.SetString("BrutePlayerNumber", "P0");
        PlayerPrefs.SetString("PumpPlayerNumber", "P0");
        PlayerPrefs.SetString("SatPlayerNumber", "P0");
    }

    public int getAvailableBotIndex()
    {
        var avaiableBotIndex = checkAndSelect();
        return avaiableBotIndex;
    }


    public int checkAndSelect()
    {
        for(var i = 0; i <= moveScripts.Count - 1; i++)
        {
            if(moveScripts[i].available)
            {
                return i;
            }
            else continue;
        }
        return -1;
    }

    
}
