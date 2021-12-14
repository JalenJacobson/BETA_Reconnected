using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Cube : MonoBehaviour
{
    public Text tutorialText;
    public string changeTextTo;
    public string objectThatShouldTrigger;
    public bool displayTextOnlyOnce;
    private bool alreadyDisplayed = false;

    void Start()
    {
        tutorialText = GameObject.Find("Tutorial").GetComponent<Text>();;
    }

    public void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if(other.name.Contains(objectThatShouldTrigger))
        {
            if(displayTextOnlyOnce)
            {
                if(alreadyDisplayed)
                {
                    return;
                }
                else {changeText();}
            }
            else changeText();
        }
        
    }

    public void changeText()
    {
        tutorialText.text = changeTextTo;
        alreadyDisplayed = true;
    }
}
