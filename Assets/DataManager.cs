using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataManager : MonoBehaviour
{
    public int levelNumber;
    public int tokensCollectedCurrentLevel;
    public double timeRemaiingCurrentLevel;
    public string saveSlot;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown("e"))
        // {
        //     saveLevelData();
        // }  
        // if(Input.GetKeyDown("r"))
        // {
        //     readLevelData();
        // }  
    }

    // public void saveLevelData()
    // {
    //     string saveObject = createSaveObject();
    //     print(saveObject);
    //     string saveKey = createSaveKey();
    //     print(saveKey);
    //     PlayerPrefs.SetString(saveKey, saveObject);
    // }

    // public string createSaveObject()
    // {
    //     LevelClass currentLevel = new LevelClass();
    //     currentLevel.tokensCollected = tokensCollectedCurrentLevel;
    //     currentLevel.timeRemaiing = timeRemaiingCurrentLevel;
    //     string jsonSaveObject = JsonUtility.ToJson(currentLevel);
    //     return jsonSaveObject;
    // }

    // public string createSaveKey()
    // {
    //     string saveKey = saveSlot + "_Level" + levelNumber.ToString();
    //     return saveKey;
    // }

    // public void readLevelData()
    // {
    //     LevelClass thisLevel = new LevelClass();
    //     string retrieveKey = saveSlot + "_Level" + levelNumber.ToString();
    //     string jsonString = PlayerPrefs.GetString(retrieveKey);
    //     thisLevel = JsonUtility.FromJson<LevelClass>(jsonString);
    //     print("tokens Collected " + thisLevel.tokensCollected);
    //     print("time remaining " + thisLevel.timeRemaiing);
    // }
}

[Serializable]
public class LevelClass
{
    public int tokensCollected;
    public double timeRemaiing;
}
