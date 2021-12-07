using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Selector : MonoBehaviour
{
    public GameObject Level_Manager;
    Level_Manager LevelManager_script;
    public int newScene;
    private int currentScene;
    

    void Start()
    {
        LevelManager_script = Level_Manager.GetComponent<Level_Manager>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    void OnTriggerEnter()
    {
        LevelManager_script.winTutorial(currentScene);
        // other.gameObject.transform.position = transform.TransformPoint(hoverPosition);
        // toggleNodeFixPosition(other.gameObject);
        // StartCoroutine(ExecuteAfterTime(.5f, other.gameObject));
    }

    void Update()
    {
    }
    


    IEnumerator ExecuteAfterTime(float time, GameObject node)
    {
        yield return new WaitForSeconds(time);
    }  

}
