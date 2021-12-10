using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceGate : IDI_Base
{
   public Animator anim;

    // Use this for initialization
    void Start () 
    {
        anim = GetComponent<Animator>();
    }

    public void toggleActive()
    {
        active = !active;
       // sendState();
    }
 
    // Update is called once per frame
    void Update () 
    {
       if(active)
       {
           forceGateDown();
       } 
    }

    public void forceGateDown()
    {
        anim.Play("ForceGateDown");
    }
}
