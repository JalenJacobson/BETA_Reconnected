using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceGate : IDI_Base
{
    public Animator anim;
    public TwoPlayerCameraFollow CameraFollow_Script;

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
       // sendState();
    }
 
    void Update () 
    {
       if(active)
       {
           forceGateDown();
       } 
    }

    public void forceGateDown()
    {
        StartCoroutine(forceGateDownSequence());
    }

    public IEnumerator forceGateDownSequence()
    {
        CameraFollow_Script.lookAtObject(gameObject);
        yield return new WaitForSeconds(1f);
        anim.Play("ForceGateDown");
    }
}
