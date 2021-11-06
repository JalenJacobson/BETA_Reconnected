using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Selector : MonoBehaviour
{
    public GameObject Level_Manager;
    Level_Manager LevelManager_script;
    public int newScene;
    
    public Vector3 hoverPosition;

    void Start()
    {
        LevelManager_script = Level_Manager.GetComponent<Level_Manager>();
        hoverPosition = new Vector3(0.0f, 15.08f, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        LevelManager_script.setSceneToGoTo(newScene);
        PlayerPrefs.SetInt("currentLevel", newScene);
        // other.gameObject.transform.position = transform.TransformPoint(hoverPosition);
        // toggleNodeFixPosition(other.gameObject);
        // StartCoroutine(ExecuteAfterTime(.5f, other.gameObject));
    }

    void Update()
    {
    }
    
    void OnTriggerExit(Collider other)
    {
        LevelManager_script.setSceneToGoTo(1);
        PlayerPrefs.SetInt("currentLevel", 1);
    }

    IEnumerator ExecuteAfterTime(float time, GameObject node)
    {
        yield return new WaitForSeconds(time);
 
        toggleNodeFixPosition(node);
 }  

    public void toggleNodeFixPosition(GameObject node)
    {
       node.SendMessage("toggleFixPosition");
    }
}
