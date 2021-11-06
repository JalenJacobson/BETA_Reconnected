using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerConnection : MonoBehaviour
{

    public float pos = 0;
    public GameObject GateDoors;
    Doors doorsOpen_script; 
    public GameObject GateLight1;
    LightOn1 lightactivate_script;
    public GameObject PowerLight1;
    LightOn1 powerlight_script;

    public GameObject GatePowerConnection1;

    public IDI_Base GatePowerConnection1_script;

    public bool holdToActivate;

    
    void Start()
    {
        doorsOpen_script = GateDoors.GetComponent<Doors>();
        lightactivate_script = GateLight1.GetComponent<LightOn1>();
        powerlight_script = PowerLight1.GetComponent<LightOn1>();
        GatePowerConnection1_script = GatePowerConnection1.GetComponent<IDI_Base>();
        // message = "Gate Power 1 Activated";
    }

    
    void Update()
    {
        //change
    }

    public void Activate(Text sndMessage)
    {
        pos = 1; 
        // doorsOpen_script.changePowerConnection1();
        GatePowerConnection1_script.toggleActive();
        lightactivate_script.changePowerConnection1();
        powerlight_script.changePowerConnection1();
        // sndMessage.text = message;
    }

    public void Deactivate()
    {
        // if(!holdToActivate)
        // {
        //     return;
        // }
        // else
        // {
        //     doorsOpen_script.changePowerConnection1();
        //     print("deactivated");  
        // }
    }
}
