using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawBoundries : MonoBehaviour
{
    public bool clawConnected = false;

    public Animator anim; 
    void Start()
    {
     anim = GetComponent<Animator>();   
    }
        void FixedUpdate()
    {
        if(clawConnected)
        {
         anim.Play("ClawBoundries");   
        }
        if(clawConnected == false)
        {
         anim.Play("ClawBoundriesClose");   
        }
        
    }


    void Update()
    {
        
    }
        public void Activate()
    {

        
    }
}
