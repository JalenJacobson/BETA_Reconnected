using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCircles : MonoBehaviour
{
    public bool available = true;
    public bool ActivateCircle = false;
    public List<Image> circles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
