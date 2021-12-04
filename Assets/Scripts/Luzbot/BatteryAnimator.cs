using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryAnimator : MonoBehaviour
{

    public Animator anim;
    public bool canAnimate = false;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }




    public void Update()
    {
        // if(canAnimate)
        // {

        // }
        // if (Input.GetKeyDown("m"))
        // {
        //     anim.Play("RechargeBattery");
        // }
    }

    public void Activate()
    {
        anim.Play("RechargeBattery");
    }
}
