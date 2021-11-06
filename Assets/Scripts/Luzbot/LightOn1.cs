using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn1 : MonoBehaviour
{
    public Animator anim;
    public bool powerConnection1 = false;

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
 void Update () {
        if (powerConnection1 == true)
        {
            anim.Play("LightOn");
        }
    }

    public void changePowerConnection1()
    {
        powerConnection1 = !powerConnection1; 
    }
}
