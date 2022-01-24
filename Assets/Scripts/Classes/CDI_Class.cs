﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDI_Class : MonoBehaviour
{

    public Animator anim;
    public string message;
    public bool botTouching = false;
    public bool botConnected = false;

    public TwoPlayerCameraFollow CameraFollow_Script;
    public GameObject quickLookObject;
    public Vector3 quickLookObjectOffset;
    public bool quickLookWhenActivated;

    public void Awake()
    {
      CameraFollow_Script = GameObject.Find("TwoPlayerCameraFollow").GetComponent<TwoPlayerCameraFollow>();
    }

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

    public virtual void activateItem()
    {
      return;
    }

    public IEnumerator activateItemSequence()
    {
        if(quickLookWhenActivated && quickLookObject != null)
        {
          CameraFollow_Script.lookAtObject(quickLookObject, quickLookObjectOffset);
        }
        yield return new WaitForSeconds(1f);
        activateItem();
    }

    //cdi class calls camera follow, then calls item activate. it just needs an item to send for the camera to follow and an offset and then an overriden item activate function in each CDI child
}
