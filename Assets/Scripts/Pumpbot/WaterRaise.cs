using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRaise : MonoBehaviour
{
   public Animator anim;

 // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
 
 // Update is called once per frame
    void Update () 
    {

    }

    public void raiseWater()
    {
        anim.Play("Drained");
    }
        public void emptyWater()
    {
        anim.Play("WaterRaise");
    }
}