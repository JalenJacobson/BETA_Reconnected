using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataManager : MonoBehaviour
{
    public string jsonCurrentLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        readLevelData();
    }

    

    public void readLevelData()
    {
        LevelClass thisLevel = new LevelClass();
        string retrieveKey = StaticVariables.saveSlot + "_Level" + Level_Manager.previousLevel.ToString();
        if(PlayerPrefs.GetString(retrieveKey) != null)
        {
            string jsonString = PlayerPrefs.GetString(retrieveKey);
            thisLevel = JsonUtility.FromJson<LevelClass>(jsonString);
            print("tokens Collected " + thisLevel.tokensCollected);
            print("time remaining " + thisLevel.timeRemaining);
        }
        else return;
        
    }
}

[Serializable]
public class LevelClass
{
    public int tokensCollected;
    public double timeRemaining;
}
