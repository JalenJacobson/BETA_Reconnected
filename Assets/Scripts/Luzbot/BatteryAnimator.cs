using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryAnimator : MonoBehaviour
{

    public Animator anim;

    public void Start()
    {
    anim = GetComponent<Animator>();
    }




    public void Update()
    {
        if (Input.GetKeyDown("m"))
        {
         anim.Play("RechargeBattery");
        }
    }
}
