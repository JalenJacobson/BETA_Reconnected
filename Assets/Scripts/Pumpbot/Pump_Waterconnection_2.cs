using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pump_Gasconnection_1 : MonoBehaviour
{
    // IDI's
    public GameObject Water_raise_1;
    WaterRaise waterraise_script;



    // Start is called before the first frame update
    public void Start()
    {
        waterraise_script = Water_raise_1.GetComponent<WaterRaise>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        waterraise_script.raiseWater();

    }
    public void Deactivate()
    {
        waterraise_script.emptyWater();

    }
}
