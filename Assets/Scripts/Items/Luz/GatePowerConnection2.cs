using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatePowerConnection2 : IDI_Base
{
    // Start is called before the first frame update
    void Start()
    {
        name = "GatePowerConnection2";
    }

    public void toggleActive()
    {
        active = !active;
        sendState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
