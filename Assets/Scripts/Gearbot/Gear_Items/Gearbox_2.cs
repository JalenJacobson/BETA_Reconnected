using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gearbox_2 : CDI_Class
{
    // public Animator anim;
    //public float pos = 0;
    public GameObject GearMoverMove;
    GearMoverMove gearmover_script;
    public GameObject GearMoverGears;
    GearMoverGears gearmovergears_script;
    public GameObject GearMoverStart;
    GearMoverGears gearmoverstart_script;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        gearmover_script = GearMoverMove.GetComponent<GearMoverMove>();
        gearmovergears_script = GearMoverGears.GetComponent<GearMoverGears>();
        gearmoverstart_script = GearMoverStart.GetComponent<GearMoverGears>();
        message = "Gate Gear 2 Activated";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void Activate(Text sndMessage)
    {
        //pos = 1; 
        gearmover_script.changeGearBox2();
        gearmovergears_script.changeGearBox2();
        gearmoverstart_script.changeGearBox2();
        anim.Play("GearTrigger");
        sndMessage.text = message;
    }

    public void Deactivate()
    {
        gearmover_script.changeGearBox2();
        gearmovergears_script.changeGearBox2();
        gearmoverstart_script.changeGearBox2();
        anim.Play("GearTrigger");
    }
}
