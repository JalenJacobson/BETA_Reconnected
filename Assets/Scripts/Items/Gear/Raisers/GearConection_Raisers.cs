using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearConection_Raisers : CDI_Class
{
    public GameObject GearRaiser;
    Boxes GearRaiser_script;
    // Start is called before the first frame update
    void Start()
    {
        GearRaiser_script = GearRaiser.GetComponent<Boxes>();
        message = "Raiser Activated";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        GearRaiser_script.Activate();
        // sndMessage.text = message;
    }
}
