using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpConnectionBox_AirVent : MonoBehaviour
{

    public GameObject AirVent;
    public AirVent AirVent_Script;
    
    void Start()
    {
        AirVent_Script = AirVent.GetComponent<AirVent>();
    }

    public void Activate()
    {
        AirVent_Script.Activate();
    }

    
}
