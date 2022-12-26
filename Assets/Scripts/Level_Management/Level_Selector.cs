using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Selector : MonoBehaviour
{
    public GameObject Level_Manager;
    Level_Manager LevelManager_Script;
    
    public int sceneToGoTo;
    public int currentScene;

    

    void Start()
    {
        Level_Manager = GameObject.FindGameObjectWithTag("Level_Manager");
        LevelManager_Script = Level_Manager.GetComponent<Level_Manager>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        
    }

    void OnTriggerEnter(Collider other)
    {
        LevelManager_Script.sceneToGoTo = sceneToGoTo;
    }
    void OnTriggerExit(Collider other)
    {
        LevelManager_Script.sceneToGoTo = -1;
    }

    void Update()
    {
          
    }
    
     
}