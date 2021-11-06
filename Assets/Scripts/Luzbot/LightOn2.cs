using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn2 : MonoBehaviour
{
    public Animator anim;
    public bool powerConnection2 = false;

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
 void Update () {
        if (powerConnection2 == true)
        {
            anim.Play("LightOn");
        }
    }

    public void changePowerConnection2()
    {
        powerConnection2 = !powerConnection2; 
    }
}
