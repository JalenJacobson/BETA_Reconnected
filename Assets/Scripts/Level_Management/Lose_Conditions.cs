using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lose_Conditions : MonoBehaviour
{
    public GameObject Level_Manager;
    Level_Manager Level_Manager_Script;

    public GameObject timerText;
    public int timeRemaining;
    public bool timeDecreasing = false;
    public bool levelNeedsCountdown = false;
    public bool allBotsDead = false;
    public bool loseFunctionCalled = false;

    public GameObject[] bots;
    public int deadBots;
    public List<Player> botsScripts;
    public GameObject bot;
    private int currentScene;


    void Start()
    {
        Level_Manager_Script = Level_Manager.GetComponent<Level_Manager>();
        timerText = GameObject.Find("TimeRemaining");
        timerText.GetComponent<Text>().text = timeRemaining.ToString();
        bots = GameObject.FindGameObjectsWithTag("Bot");
        getBotScripts();
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    
    void Update()
    {
        checkDeadBots();
        if(levelNeedsCountdown)
        {
            if(!timeDecreasing && timeRemaining > 0)
            {
                StartCoroutine(countDown());
            }
            if(!loseFunctionCalled)
            {
                if(timeRemaining <= 0 || allBotsDead)
                {   
                   lose();
                }
            }
            
        }
    }

    public void getBotScripts()
    {
        foreach(GameObject bot in bots)
        {
            botsScripts.Add(bot.GetComponent<Player>());
        }
    }

    void checkDeadBots()
    {
        var deadBots = 0;
        foreach(Player botScript in botsScripts)
        {
            if(botScript.batteryDead)
            {
                deadBots ++;
            }
        }
        if(deadBots >= bots.Length)
        {
            allBotsDead = true;
        }
    }

    public IEnumerator countDown()
    {
        timeDecreasing = true;
        yield return new WaitForSeconds(1);
        timeRemaining -= 1;
        timerText.GetComponent<Text>().text = timeRemaining.ToString();
        timeDecreasing = false;
    }

    public void lose()
    {
        loseFunctionCalled = true;
        Level_Manager_Script.loseTutorial(currentScene);
    }
}
