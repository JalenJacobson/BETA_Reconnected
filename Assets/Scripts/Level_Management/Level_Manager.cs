using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net.Http;
using System;
using System.Text;

public class Level_Manager : MonoBehaviour
{
    public int sceneToGoTo;
    public Animator transition;
    public float transitionTime = 1f;
    
    public float levelValues = 0;

    public async void Start()
    {
        sceneToGoTo = 1;
        levelValues = 0;
        print("level value" + levelValues);
        
    }

    void Update()
    {

    }


    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(sceneToGoTo));
    }
    
    public void loadCurrentLevel()
    {
        sceneToGoTo = PlayerPrefs.GetInt("currentLevel");
        print(sceneToGoTo);
        SceneManager.LoadScene(sceneToGoTo);
        // this.StartCoroutine(LoadLevel(sceneToGoTo));
        // sceneToGoTo = 1;
    }
    
    public void loadLevelSelectLevel()
    {
        sceneToGoTo = 1;
        SceneManager.LoadScene(sceneToGoTo);
        // StartCoroutine(LoadLevel(sceneToGoTo));
        // sceneToGoTo = 1;
    }
    
    public void loadGameOverLevel()
    {
        sceneToGoTo = 2;
        SceneManager.LoadScene(sceneToGoTo);
        // StartCoroutine(LoadLevel(sceneToGoTo));
        // sceneToGoTo = 1;
    }

    public void setSceneToGoTo(int nextScene)
    {
        sceneToGoTo = nextScene;
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }


//================= get next level ====================

    // public void setLevelValues(int valueToAdd)
    // {
    //     levelValues = levelValues + valueToAdd;
    // }
    

//================= Character Selection =====================
    public void setPrefsGear()
    {
        // PlayerPrefs.SetInt("selectedHero", 0);
        // PlayerPrefs.SetString("GearAxisHorizontal", "HorizontalPlayer2");
        // PlayerPrefs.SetString("GearAxisVertical", "VerticalPlayer2");
        print("level value" + levelValues);
        levelValues = levelValues + 1;
        print("level value" + levelValues);
    }
    public void setPrefsLuz()
    {
        PlayerPrefs.SetInt("selectedHero", 1);
        print("level value" + levelValues);
        levelValues = levelValues + 1;
        print("level value" + levelValues);
    }
    public void setPrefsBrute()
    {
        PlayerPrefs.SetInt("selectedHero", 2);
    }
    public void setPrefsPump()
    {
        PlayerPrefs.SetInt("selectedHero", 3);
    }
    public void setPrefsSat()
    {
        PlayerPrefs.SetInt("selectedHero", 4);
    }
}

[Serializable]
public class Scene
{
    public string name;
    public int sceneNumber;
    public bool startTheGame;

    public int playersInParty;
    public int playersReady;
}

[Serializable]
public class SceneUpdate
{
    public Scene levelmanager;
}
