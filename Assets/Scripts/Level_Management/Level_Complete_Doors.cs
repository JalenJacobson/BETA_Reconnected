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
    public Scene scene;

    // Saving Data Stuff
    public int tokensCollectedCurrentLevel;
    public double timeRemaiingCurrentLevel;

    public GameObject Doors;
    public Doors Doors_script;
    public GameObject lose_condition;
    public Lose_Conditions lose_condition_script;
    

    void Start()
    {
        LevelManager_script = Level_Manager.GetComponent<Level_Manager>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        bots = GameObject.FindGameObjectsWithTag("Bot");
        Lights = GameObject.Find("Lights");
        Winlights = Lights.GetComponent<LevelWin>(); 
        scene = SceneManager.GetActiveScene();
        print("BUILD INDEX " + scene.buildIndex);
        Doors = GameObject.FindGameObjectWithTag("Gate");
        Doors_script = Doors.GetComponent<Doors>();
        lose_condition = GameObject.Find("Lose_Conditions");
        lose_condition_script = lose_condition.GetComponent<Lose_Conditions>();
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
            PlayerPrefs.SetInt("highestLevelComplete", scene.buildIndex);
            saveLevelData();
            Winlights.Win();
            LevelManager_script.winTutorial(currentScene);
        } 
        if(Input.GetKeyDown("e"))
        {
            print(StaticVariables.saveSlot);
        }   
    }

    
    
    IEnumerator ExecuteAfterTime(float time, GameObject node)
    {
        yield return new WaitForSeconds(time);
    }  

    public void saveLevelData()
    {
        string saveObject = createSaveObject();
        print(saveObject);
        string saveKey = createSaveKey();
        print(saveKey);
        PlayerPrefs.SetString(saveKey, saveObject);
    }

    public string createSaveObject()
    {
        LevelClass currentLevel = new LevelClass();
        currentLevel.tokensCollected = Doors_script.tokensCollected;;
        string jsonSaveObject = JsonUtility.ToJson(currentLevel);
        return jsonSaveObject;
    }

    public string createSaveKey()
    {
        string saveKey = StaticVariables.saveSlot + "_Level" + currentScene.ToString();
        return saveKey;
    }
}

