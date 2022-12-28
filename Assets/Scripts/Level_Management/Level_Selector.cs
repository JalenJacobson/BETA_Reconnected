using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Selector : MonoBehaviour
{
    public GameObject Level_Manager;
    Level_Manager LevelManager_Script;
    public Animator anim;
    
    public int LevelNumber;
    public int sceneToGoTo;
    public int currentScene;
    public bool available = false;
    public bool nodeEntered = false;
    public bool won = false;

    

    void Start()
    {
        sceneToGoTo = LevelNumber;
        Level_Manager = GameObject.FindGameObjectWithTag("Level_Manager");
        LevelManager_Script = Level_Manager.GetComponent<Level_Manager>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        anim = GetComponent<Animator>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        nodeEntered = true;
    }
    void OnTriggerExit(Collider other)
    {
        nodeEntered = false;
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
    }

    void Update()
    {
        if(nodeEntered && Input.GetKeyDown("u"))
        {
            LevelManager_Script.loadSceneFromLevelSelect(sceneToGoTo, available);
        }

        if(available == true)
        {
            anim.Play("Level_Available");
        }
        if(won == true)
        {
            anim.Play("Level_Won");
        }
    }

    
    
     
}