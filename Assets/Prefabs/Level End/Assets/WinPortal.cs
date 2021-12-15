using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPortal : MonoBehaviour
{
    public GameObject Lights;
    LevelWin Winlights;
    void Start()
    {
        Winlights = Lights.GetComponent<LevelWin>();   
    }

     void OnTriggerEnter(Collider other)
    {
        Winlights.Win();
    }
}
