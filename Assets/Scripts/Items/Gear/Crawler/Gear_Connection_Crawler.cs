using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_Connection_Crawler : CDI_Class
{

    public GameObject Stand;
    public Gear_Crawler StandMove_Script;
    
    void Start()
    {
        StandMove_Script = Stand.GetComponent<Gear_Crawler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void connect()
    {
        StandMove_Script.standConnected = true;
    }
    void disconnect()
    {
        StandMove_Script.standConnected = false;
    }
}
