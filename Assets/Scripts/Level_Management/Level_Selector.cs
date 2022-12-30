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
        if(available == false)
        {
            anim.Play("Level_Locked_Indicator");
        }
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
    }

    void Update()
    {
        if(nodeEntered && Input.GetKeyDown("u") || Input.GetButtonDown("activate1"))
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