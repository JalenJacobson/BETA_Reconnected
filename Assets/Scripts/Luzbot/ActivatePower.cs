﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePower : MonoBehaviour
{
   public Animator anim;

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
 void Update () {
        if (Input.GetKeyDown("c"))
        {
            anim.Play("ActivatePower");

        }
        if (Input.GetKeyDown("b"))
        {
            anim.Play("ReleasePower");

        }
    }

public void Play()
{
   anim.Play("ActivatePower"); 
}    
public void Stop()
{
    anim.Play("ReleasePower");
}
}