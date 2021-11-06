using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gearbox1 : MonoBehaviour
{
    // public GameObject GateDoors;
    // Doors doorsOpen_script;
    public GameObject GateGearObj;
    IDI_Base gategearactivate_script;
    public Animator anim;

    public bool holdToActivate;
    

    void Start()
    {
        // doorsOpen_script = GateDoors.GetComponent<Doors>();
        anim = GetComponent<Animator>();
        gategearactivate_script = GateGearObj.GetComponent<IDI_Base>();
        // message = "Gate Gear 1 Activated";
    }

    public void Activate(Text sndMessage)
    {
            // doorsOpen_script.changeGearBox1();
            gategearactivate_script.toggleActive();
            anim.Play("GearTrigger");
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
        //     doorsOpen_script.changeGearBox1();
        //     print("deactivated");  
        // }
    }
}
