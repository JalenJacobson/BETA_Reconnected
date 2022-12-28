using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Level_Manager;
    Level_Manager Level_Manager_Script;
    public bool needsPauseMenu = false;

    public bool gameIsPaused = false;
    public GameObject PauseMenuUI;
    public AudioSource Music;
    public int currentScene;
    
    void Awake()
    {
        if(!needsPauseMenu) return;
        Level_Manager = GameObject.FindGameObjectWithTag("Level_Manager");
        PauseMenuUI = GameObject.Find("PauseMenu");
        Music = GameObject.Find("Music").GetComponent<AudioSource>();
    }

    void Start()
    {
        if(!needsPauseMenu) return;
        PauseMenuUI.SetActive(false);
        Level_Manager_Script = Level_Manager.GetComponent<Level_Manager>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if(!needsPauseMenu) return;
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(gameIsPaused)
            {
               resume();
            }
            else if(!gameIsPaused)
            {    
               pause();
            }
        }
    }

    public void resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Music.volume = 1;
    }

    public void pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Music.volume = .24f;
    }

    public void replay()
    {
        Time.timeScale = 1f;
        Level_Manager_Script.replayLevel(currentScene);
    }

    public void mainMenu()
    {
        Time.timeScale = 1f;
        Level_Manager_Script.loadLevelSelectLevel();
    }
}
