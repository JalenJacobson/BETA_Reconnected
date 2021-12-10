using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateGear2 : IDI_Base
{
   public Animator anim;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
        name = "GateGear2";
 }

 public void toggleActive()
    {
        active = !active;
        //sendState();
    }
 
 // Update is called once per frame
 void Update () {
        
    }

    // public void changeGearBox2()
    // {
    //     print("worked");
    //     gearBox2 = !gearBox2; 
    // }
}
