using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceGate : IDI_Base
{
    public Animator anim;
    public TwoPlayerCameraFollow CameraFollow_Script;
    public bool activated = false;

    void Awake()
    {
        CameraFollow_Script = GameObject.Find("TwoPlayerCameraFollow").GetComponent<TwoPlayerCameraFollow>();
    }
    
    void Start () 
    {
        anim = GetComponent<Animator>();
    }

    public void toggleActive()
    {
        active = !active;
    }
 
    void Update () 
    {
       if(active && !activated)
       {
           forceGateDown();
           activated = true;
       } 
    }

    public void forceGateDown()
    {
        anim.Play("ForceGateDown");
    }
}
