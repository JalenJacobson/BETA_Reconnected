﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMoverGears : MonoBehaviour
{
public GameObject GearMoverBox;
public Animator anim;
public bool gearBox2 = false;
public GameObject touching = null;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    } 
    
    void OnTriggerEnter(Collider other)
    {
        //   anim.Play("Stop");
        print(other.name);
        if(other.name.Contains("Stand"))
        {
             touching = other.gameObject;
             touching.SendMessage("toggleX");
        }
    
    } 
    void OnTriggerExit(Collider other)
    {
        //   anim.Play("Stop");
        print(other.name);
        if(other.name.Contains("Stand"))
        {
             touching = other.gameObject;
             touching.SendMessage("toggleX");
        }
    
    } 
    
    public void Update()
    {
        if (gearBox2 == true)
        {
            anim.Play("Forward");        
        }  
    
    
        if (gearBox2 == false)
        {
            anim.Play("Backward");        
        }
    }
    

}
