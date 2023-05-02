using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectPortal_Manager : MonoBehaviour
{

    public GameObject[] LevelSelectPortals;
    public List<Level_Selector> LevelSelector_Scripts;
    public GameObject forcegate_gate;
    public ForceGate forcegate_script;

    public int highestLevelComplete;

    void Awake()
    {
        //PlayerPrefs.SetInt("highestLevelComplete", 40);
        LevelSelectPortals = GameObject.FindGameObjectsWithTag("LevelSelect_Portal");
        foreach(GameObject portal in LevelSelectPortals)
        {
            LevelSelector_Scripts.Add(portal.GetComponent<Level_Selector>());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        forcegate_script = forcegate_gate.GetComponent<ForceGate>();
        highestLevelComplete = PlayerPrefs.GetInt("highestLevelComplete");

        print("highest" + highestLevelComplete);

        foreach(Level_Selector level in LevelSelector_Scripts)
        {
            if(level.LevelNumber == highestLevelComplete + 1)
            {
                level.levelAvailable();
            }
            else if(level.LevelNumber <= highestLevelComplete)
            {
                level.levelWon();
            }
            else
            {
                // level.levelUnavailable();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(highestLevelComplete >= 13)
        {
            forcegate_script.toggleActive();
        }
        
    }
}
