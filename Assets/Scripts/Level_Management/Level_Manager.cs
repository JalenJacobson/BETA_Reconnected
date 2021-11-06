using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net.Http;
using System;
using System.Text;

public class Level_Manager : MonoBehaviour
{
    private static readonly HttpClient client = new HttpClient();
    public int sceneToGoTo;
    public Animator transition;
    public float transitionTime = 1f;

    public bool startTheGame;
    public bool gameStarted;

    public int playersInParty;
    public int playersReady;

    private int frameCount = 0;
    // private string selectedHero;
    public string gearAxis;

    public async void Start()
    {
        sceneToGoTo = 1;
        addPlayerToParty();
        gearAxis = PlayerPrefs.GetString("GearAxisHorizontal");
        
    }

    public async void addPlayerToParty()
    {
        updateScene();
        print(playersInParty);
        playersInParty ++;
        print(playersInParty);
        // selectedHeroName = PlayerPrefs.GetString("selectedHero");
        // print(selectedHeroName);
        sendState();
    }

    void Update()
    {
        if(startTheGame && !gameStarted)
        {
            LoadNextLevel();
        }

        if(sceneToGoTo != 1 && Input.GetKeyDown("q"))
        {
            startGame();
        }

        frameCount++;
        if(frameCount%100 == 0)
        {
         updateScene();
        }
    }

    public void ready()
    {
        playersReady ++;
        sendState();
    }

    public void startGame()
    {
        startTheGame = true;
        sendState();
    }

    public void LoadNextLevel()
    {
        gameStarted = true;
        StartCoroutine(LoadLevel(sceneToGoTo));
        // sceneToGoTo = 1;
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


//================= Update Network Scene ====================

    public async void sendState()
    {
        
        // time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        var scene = new Scene();
        scene.name = "levelmanager";
        scene.sceneNumber = sceneToGoTo;
        scene.startTheGame = startTheGame;
        scene.playersInParty = playersInParty;
        scene.playersReady = playersReady;
        
    
        string json = JsonUtility.ToJson(scene);

        // var response = await client.PostAsync("http://74.207.254.19:7000/scene/save", new StringContent(json, Encoding.UTF8, "application/json"));
        var response = await client.PostAsync("http://localhost:7000/scene/save", new StringContent(json, Encoding.UTF8, "application/json"));

        var responseString = await response.Content.ReadAsStringAsync();
    }

    public async void updateScene()
    {
        // var positionResponse = await client.PostAsync("http://74.207.254.19:7000/scene", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));
        var positionResponse = await client.PostAsync("http://localhost:7000/scene", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

        var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        var scene = JsonUtility.FromJson<SceneUpdate>(positionResponseString);
        print(scene.levelmanager.playersInParty);
        startTheGame = scene.levelmanager.startTheGame;
        playersInParty = scene.levelmanager.playersInParty;
        playersReady = scene.levelmanager.playersReady;
        print(playersInParty);
    }

//================= Character Selection =====================
    public void setPrefsGear()
    {
        PlayerPrefs.SetInt("selectedHero", 0);
        PlayerPrefs.SetString("GearAxisHorizontal", "HorizontalPlayer2");
        PlayerPrefs.SetString("GearAxisVertical", "VerticalPlayer2");
        print("AAAAAAA- it was set - AAAAA");
    }
    public void setPrefsLuz()
    {
        PlayerPrefs.SetInt("selectedHero", 1);
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
