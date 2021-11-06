using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{

    public int playersReady;
    public float gameTimeRemaining;
    public bool virusDelivered = false;

    public GameObject Level_Manager;
    public Level_Manager levelManager_script;

    public Text consoleTimeRemaining;
    public Color redDanger;
    
    // Start is called before the first frame update
    void Start()
    {
        levelManager_script = Level_Manager.GetComponent<Level_Manager>();
        redDanger = new Color(1f, 0.1f, 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        consoleTimeRemaining.text = gameTimeRemaining.ToString("0.00");
        if(virusDelivered == true)
        {
            if(gameTimeRemaining > 0)
            {
                gameTimeRemaining -= Time.deltaTime;
            }
            else
            {
                gameTimeRemaining = 0f;
                levelManager_script.loadGameOverLevel();
            }
            if(playersReady == 5)
            {
                gameTimeRemaining = 0f;
                print("Level complete");
            }
        }
        else
        {
            if(playersReady < 5)
            {
                gameTimeRemaining -= Time.deltaTime;
            }
        }
    }

    public void addPlayerReady()
    {
        playersReady += 1;
    }
    public void removePlayerReady()
    {
        playersReady -= 1;
    }

    public void deliverVirus()
    {
        gameTimeRemaining = 30f;
        consoleTimeRemaining.color = redDanger;
        virusDelivered = true;
    }
}
