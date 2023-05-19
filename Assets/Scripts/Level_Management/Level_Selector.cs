using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_Selector : MonoBehaviour
{
    public GameObject LevelManager;
    Level_Manager LevelManager_Script;
    public Animator anim;
    public GameObject[] TokenCollectedIndicatorImages;
    
    public int LevelNumber;
    public int sceneToGoTo;
    public int currentScene;
    public bool available = false;
    public bool nodeEntered = false;
    public bool won = false;

    public int tokensCollected;
    public double timeRemaining;

    

    void Start()
    {
        sceneToGoTo = LevelNumber;
        LevelManager = GameObject.FindGameObjectWithTag("Level_Manager");
        LevelManager_Script = LevelManager.GetComponent<Level_Manager>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        anim = GetComponent<Animator>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        nodeEntered = true;
        if(available == false)
        {
            anim.Play("Level_Locked_Indicator");
        }
        for(var i = 0; i< tokensCollected; i++)
        {
            TokenCollectedIndicatorImages[i].GetComponent<Image>().enabled = true;
        }

        PlayerPrefs.SetInt("mostRecentLevelPlayed", LevelNumber);
        // else if(available == true)
        // {
        //     anim.Play("Level_Available_Indicator");
        // }
    }
    void OnTriggerExit(Collider other)
    {
        nodeEntered = false;
        if(available == false)
        {
            anim.Play("Level_Locked");
        }
        foreach(GameObject tokenImage in TokenCollectedIndicatorImages)
        {
            tokenImage.GetComponent<Image>().enabled = false;
        }
        // else if(available == true)
        // {
        //     anim.Play("Level_Available");
        // }
    }

    public void levelAvailable()
    {
        // change color to blue
        available = true;
    }
    public void levelWon()
    {
        // change color to blue
        won = true;
        available = true;
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
            tokensCollected = thisLevel.tokensCollected;
        }
        else return;
        
    }

    private void gotoLevel()
     {
        print("NEXTLEVEL");

        if(nodeEntered && available)
        {
            LevelManager_Script.loadSceneFromLevelSelect(sceneToGoTo, available);
        }
     }

    void Update()
    {
        if(nodeEntered && available && Input.GetKeyDown("u"))
        {
            LevelManager_Script.loadSceneFromLevelSelect(sceneToGoTo, available);
        }

        if(available && nodeEntered == true)
        {
            anim.Play("Level_Available_Indicator");
        }

        else if(won == false && available == true && nodeEntered == false)
        {
            anim.Play("Level_Available");
        }

        else if(won && available == true && nodeEntered == false)
        {
            anim.Play("Level_Won");
        }

    }

    
    
     
}