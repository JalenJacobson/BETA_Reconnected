using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Http;
using System;
using System.Text;

public class HeroSelectPlayer : MonoBehaviour
{
    
    public bool isSelected;
    public bool isLocalPlayer;
    public bool isUp;

    public bool available = true;

    public List<Image> circles;
    
    public void makeUnavailable(int playerIndex)
    {
        circles[playerIndex].enabled = true;
        available = false; 
    }

     public void makeAvailable()
    {
        foreach(Image circle in circles)
        {
            circle.enabled = false;
        }
        available = true;
    }
}

