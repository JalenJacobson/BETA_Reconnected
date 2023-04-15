using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sat_Download_1 : CDI_Class
{
   public string token = "1";
   public bool Active = false;
   public GameObject Key;
   public GameObject Sat;
    // public GameObject forcegate_gate;
    // ForceGate forcegate_script;

    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Sat = GameObject.Find("SatBot");
        // forcegate_script = forcegate_gate.GetComponent<ForceGate>();
    }

    // Update is called once per frame
    void Update()
    {
        InfoButtons();

    }

    void InfoButtons()
    {
        if(Active == true)
        {
            anim.Play("SatDoorActivate");
        }

    }

    void Activate()
    {
     Active = true;   
     Key.transform.SetParent(Sat.transform);   
    }

}
