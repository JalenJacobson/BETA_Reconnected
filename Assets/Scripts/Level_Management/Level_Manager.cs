using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net.Http;
using System;
using System.Text;

public class Level_Manager : MonoBehaviour
{
    public int sceneToGoTo = -1;
    public Animator transition;
    public float transitionTime = 1f;
    public static int oldTutorialLevel;
    public string levelValuePlayerOne = "";
    public string levelValuePlayerTwo = "";
    

    public async void Start()
    {
        sceneToGoTo = -1;
        
    }

    void Update()
    {
        // if(sceneToGoTo != -1 && Input.GetKeyDown("u"))
        // {
        //     SceneManager.LoadScene(sceneToGoTo);
        // }
    }

    public void loadSceneFromLevelSelect(int sceneToGoToFromPortal, bool availableFromPortal)
    {
        if(availableFromPortal)
        {
            SceneManager.LoadScene(sceneToGoToFromPortal);
        }
        else
        {
            print("level is locked");
            // we can put some UI here that will tell player they need to unlock level if we want
            return;
        }    
    }
       
    public void Back()
    {
        StartCoroutine(StartBack());
    }

    IEnumerator StartBack()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    public void LoadNextLevel()
    {
        var nextScene = getSceneValue();
        print(nextScene);
        StartCoroutine(LoadLevel(nextScene));
    }

    public int getSceneValue()
    {
        var levelValueString = levelValuePlayerOne + levelValuePlayerTwo;
        if(levelValueString == "gearluz" || levelValueString == "luzgear")
        {
            return 2;
        }
        else if(levelValueString == "gearbrute" || levelValueString == "brutegear")
        {
            return 3;
        }
        else if(levelValueString == "gearpump" || levelValueString == "pumpgear")
        {
            return 4;
        }
        else if(levelValueString == "gearsat" || levelValueString == "satgear")
        {
            return 5;
        }
        else if(levelValueString == "luzbrute" || levelValueString == "bruteluz")
        {
            return 6;
        }
        else if(levelValueString == "pumpluz" || levelValueString == "luzpump")
        {
            return 7;
        }
        else if(levelValueString == "brutepump" || levelValueString == "pumpbrute")
        {
            return 8;
        }
        else if(levelValueString == "brutesat" || levelValueString == "satbrute")
        {
            return 9;
        }
        else if(levelValueString == "pumpsat" || levelValueString == "satpump")
        {
            return 10;
        }
        else if(levelValueString == "satluz" || levelValueString == "luzsat")
        {
            return 11;
        }
        else return 1;
    }
    
    public void loadCurrentLevel()
    {
        sceneToGoTo = PlayerPrefs.GetInt("currentLevel");
        print(sceneToGoTo);
        SceneManager.LoadScene(sceneToGoTo);
    }
    public void loadStoryMode()
    {
        StartCoroutine(LoadStoryMode());
    }
    IEnumerator LoadStoryMode()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(5);
    }
    
    public void loadLevelSelectLevel()
    {
        StartCoroutine(loadLevelSelectLevelSelect());
    }
    IEnumerator loadLevelSelectLevelSelect()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
    
    public void loadGameOverLevel()
    {
        sceneToGoTo = 3;
        SceneManager.LoadScene(sceneToGoTo);
    }

    public void setSceneToGoTo(int nextScene)
    {
        sceneToGoTo = nextScene;
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void replayLevel(int replayLevel)
    {
        StartCoroutine(replayLevelCoroutine(replayLevel));
    }

    IEnumerator replayLevelCoroutine(int levelIndex)
    {
        print(levelIndex);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
    
    public void returnToMainMenu()
    {
        StartCoroutine(returnToMainMenuCoroutine());
    }

    IEnumerator returnToMainMenuCoroutine()
    {

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(1);
    }




//================= Tutorial  ====================

    public void Tutorial()
    {
        setTutorialControls();
        StartCoroutine(StartTutorial());
    }

    public void winTutorial(int sendingTutorialLevel)
    {
        print(sendingTutorialLevel);
        oldTutorialLevel = sendingTutorialLevel;
        StartCoroutine(startTutorialWin());
    }
    
    IEnumerator startTutorialWin()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("1_WinScreen");
    }
    
    public void loseTutorial(int sendingTutorialLevel)
    {
        print(sendingTutorialLevel);
        oldTutorialLevel = sendingTutorialLevel;
        StartCoroutine(startTutorialLose());
    }
    
    IEnumerator startTutorialLose()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(23);
    }
    
    IEnumerator StartTutorial()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(13);
    }

    public void continueTutorial()
    {
        StartCoroutine(StartcontinueTutorial());
    }

    IEnumerator StartcontinueTutorial()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level_Select");
    }

    public void replayTutorial()
    {
        StartCoroutine(StartreplayTutorial());
    }

    IEnumerator StartreplayTutorial()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(oldTutorialLevel);
    }
    
    public void NextTurtorialLevel()
    {
        StartCoroutine(LoadNextTutorialLevel());
    }
    
    IEnumerator LoadNextTutorialLevel()
    {
        var nextScene = oldTutorialLevel +2;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(nextScene);
    }

    public void setTutorialControls()
    {
        setPrefsGear1();
        setPrefsLuz1();
        setPrefsBrute1();
        setPrefsPump1();
        setPrefsSat2();
    }

//================= Character Selection P1 =====================
    
    
    
    public void setPrefsGear1()
    {
        PlayerPrefs.SetString("GearPlayerNumber", "P1");
        PlayerPrefs.SetString("GearAxisHorizontal", "Horizontal");
        PlayerPrefs.SetString("GearAxisVertical", "Vertical");
        levelValuePlayerOne = "gear";
        
    }
    public void setPrefsLuz1()
    {   
        PlayerPrefs.SetString("LuzPlayerNumber", "P1");
        PlayerPrefs.SetString("LuzAxisHorizontal", "Horizontal");
        PlayerPrefs.SetString("LuzAxisVertical", "Vertical");
        levelValuePlayerOne = "luz";
    }
    public void setPrefsBrute1()
    {   
        PlayerPrefs.SetString("BrutePlayerNumber", "P1");
        PlayerPrefs.SetString("BruteAxisHorizontal", "Horizontal");
        PlayerPrefs.SetString("BruteAxisVertical", "Vertical");
        levelValuePlayerOne = "brute";
    }
    public void setPrefsPump1()
    {
        PlayerPrefs.SetString("PumpPlayerNumber", "P1");
        PlayerPrefs.SetString("PumpAxisHorizontal", "Horizontal");
        PlayerPrefs.SetString("PumpAxisVertical", "Vertical");
        levelValuePlayerOne = "pump";
    }
    public void setPrefsSat1()
    {
        PlayerPrefs.SetString("SatPlayerNumber", "P1");
        PlayerPrefs.SetString("SatAxisHorizontal", "Horizontal");
        PlayerPrefs.SetString("SatAxisVertical", "Vertical");
        levelValuePlayerOne = "sat";
    }
    
//================= Character Selection P2 =====================
    public void setPrefsGear2()
    {
        PlayerPrefs.SetString("GearPlayerNumber", "P2");
        PlayerPrefs.SetString("GearAxisHorizontal", "HorizontalPlayer2");
        PlayerPrefs.SetString("GearAxisVertical", "VerticalPlayer2");
        levelValuePlayerTwo = "gear";
        
    }
    public void setPrefsLuz2()
    {   
        PlayerPrefs.SetString("LuzPlayerNumber", "P2");
        PlayerPrefs.SetString("LuzAxisHorizontal", "HorizontalPlayer2");
        PlayerPrefs.SetString("LuzAxisVertical", "VerticalPlayer2");
        levelValuePlayerTwo = "luz";
    }
    public void setPrefsBrute2()
    {   
        PlayerPrefs.SetString("BrutePlayerNumber", "P2");
        PlayerPrefs.SetString("BruteAxisHorizontal", "HorizontalPlayer2");
        PlayerPrefs.SetString("BruteAxisVertical", "VerticalPlayer2");
        levelValuePlayerTwo = "brute";
    }
    public void setPrefsPump2()
    {
        PlayerPrefs.SetString("PumpPlayerNumber", "P2");
        PlayerPrefs.SetString("PumpAxisHorizontal", "HorizontalPlayer2");
        PlayerPrefs.SetString("PumpAxisVertical", "VerticalPlayer2");
        levelValuePlayerTwo = "pump";
    }
    public void setPrefsSat2()
    {
        PlayerPrefs.SetString("SatPlayerNumber", "P2");
        PlayerPrefs.SetString("SatAxisHorizontal", "HorizontalPlayer2");
        PlayerPrefs.SetString("SatAxisVertical", "VerticalPlayer2");
        levelValuePlayerTwo = "sat";
    }
}

// [Serializable]
// public class Scene
// {
//     public string name;
//     public int sceneNumber;
//     public bool startTheGame;

//     public int playersInParty;
//     public int playersReady;
// }

// [Serializable]
// public class SceneUpdate
// {
//     public Scene levelmanager;
// }
