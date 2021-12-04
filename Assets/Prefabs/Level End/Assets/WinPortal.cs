using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPortal : MonoBehaviour
{
    public GameObject Lights;
    LevelWin Winlights;
    // Start is called before the first frame update
    void Start()
    {
     Winlights = Lights.GetComponent<LevelWin>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other)
    {
     Winlights.Win();
    }
}
