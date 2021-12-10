using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateGear : IDI_Base
{
   public Animator anim;

   

 // Use this for initialization
    void Start () 
    {
        anim = GetComponent<Animator>();
        name = "GateGear";
    }

    public void toggleActive()
    {
        active = !active;
        //sendState();
    }
 
 // Update is called once per frame
    void Update () 
    {
        
    }

    // public void changeGearBox1()
    // {
    //     print("worked");
    //     gearBox1 = !gearBox1; 
    // }
}
