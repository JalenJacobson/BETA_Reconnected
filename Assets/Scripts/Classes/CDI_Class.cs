using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDI_Class : MonoBehaviour
{

    public Animator anim;
    public string message;
    public bool botTouching = false;
    public bool botConnected = false;

    public void toggleBotTouching()
    {
      botTouching = !botTouching;  
    }
    public void toggleBotConnected()
    {
      botConnected = !botConnected;  
    }
    public void toggleBotBoth()
    {
      botConnected = false;
      botTouching = false;  
    }

    public virtual void Activate(Text errMessage)
    {
    }
}
