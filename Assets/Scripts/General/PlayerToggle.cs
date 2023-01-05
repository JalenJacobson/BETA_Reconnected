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
    public GameObject[] playersGameObject;
    public List<Player1_Controller> playersScripts;
    

    public int player1;
    public int player2;
    
    void Awake()
    {
        playersGameObject = GameObject.FindGameObjectsWithTag("PlayerController");
        foreach(GameObject player in playersGameObject)
        {
            playersScripts.Add(player.GetComponent<Player1_Controller>());
        }

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
        
    }

    

    void Start()
    {
        setStartingBots();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setStartingBots()
    {
        foreach(Player1_Controller playerScript in playersScripts)
        {
            print("StartingBot" + playerScript.startingBot);
            for(var i = 0; i <= bots.Count - 1; i++)
            {
                if(bots[i].name.Contains(playerScript.startingBot))
                {
                    playerScript.BotControlling = bots[i];
                    playerScript.BotControlling_Script = moveScripts[i];
                    playerScript.TriggerCube_Script = triggerScripts[i];
                    bots.Remove(bots[i]);
                    moveScripts.Remove(moveScripts[i]);
                    triggerScripts.Remove(triggerScripts[i]);
                }
                else continue;
            }
        //    return;
        }
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
