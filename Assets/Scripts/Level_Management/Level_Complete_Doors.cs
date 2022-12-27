using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Complete_Doors : MonoBehaviour
{
    public GameObject Level_Manager;
    Level_Manager LevelManager_script;
    public GameObject Lights;
    LevelWin Winlights;

    public int newScene;
    private int currentScene;

    public GameObject[] bots;
    public int finishedBots = 0;

    void Start()
    {
        LevelManager_script = Level_Manager.GetComponent<Level_Manager>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        bots = GameObject.FindGameObjectsWithTag("Bot");
        Lights = GameObject.Find("Lights");
        Winlights = Lights.GetComponent<LevelWin>(); 
    }

    void OnTriggerEnter(Collider other)
    {
        var characterName = other.name;
        if(characterName == "Brute" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump" ||characterName == "IdleLuz")
        {
            finishedBots++;
            other.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if(finishedBots >= bots.Length)
        {
            Winlights.Win();
            LevelManager_script.winTutorial(currentScene);
        }   
    }
    
    IEnumerator ExecuteAfterTime(float time, GameObject node)
    {
        yield return new WaitForSeconds(time);
    }  
}