using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Toggle_LevelSelect : MonoBehaviour
{
    // public GameObject[] botsInitial;
    public List<GameObject> bots;
    public List<HeroSelectPlayer> selectScripts;

    public List<Image> Bubbles;

    void Awake()
    {
        foreach (GameObject bot in bots)
        {
            selectScripts.Add(bot.GetComponent<HeroSelectPlayer>());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getAvailableBotIndex()
    {
        var avaiableBotIndex = checkAndSelect();
        return avaiableBotIndex;
    }


    public int checkAndSelect()
    {
        for(var i = 0; i <= selectScripts.Count - 1; i++)
        {
            if(selectScripts[i].available)
            {
                return i;
            }
            else continue;
        }
        return -1;
    }

    public int getNextAvailableBotIndex(int currentBotIndex)
    {
        var availableBotIndex_LevelSelect = checkAndSelect_LevelSelect_Next(currentBotIndex);
        print(availableBotIndex_LevelSelect);
        return availableBotIndex_LevelSelect;

    }

    public int checkAndSelect_LevelSelect_Next(int tryIndex)
    {
        // int newIndex = (tryIndex + 1) % bots.Count;
        for(var i = tryIndex + 1; i < selectScripts.Count; i++)
        {
            if(selectScripts[i].available)
            {
                return i;
            }
            else continue;
        }
        
        return tryIndex;

    }

    public int getPreviousAvailableBotIndex(int currentBotIndex)
    {
       
        var availableBotIndex_LevelSelect = checkAndSelect_LevelSelect_Previous(currentBotIndex);
        
        print(availableBotIndex_LevelSelect);
        return availableBotIndex_LevelSelect;

    }

    public int checkAndSelect_LevelSelect_Previous(int tryIndex)
    {
        for(var i = tryIndex - 1; i>= 0; i--)
        {
            if(selectScripts[i].available)
            {
                return i;
            }
            else continue;
        }
        return tryIndex;

    }


    
    
    
}
