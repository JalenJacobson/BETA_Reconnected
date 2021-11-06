using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerConnection_LuzLifter : CDI_Class
{
    public GameObject LuzLifter;
    Lifter LuzLifter_script;
    // Start is called before the first frame update
    void Start()
    {
        LuzLifter_script = LuzLifter.GetComponent<Lifter>();
        message = "Lift Activated";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate(Text sndMessage)
    {
        LuzLifter_script.Activate();
        sndMessage.text = message;
    }
}
