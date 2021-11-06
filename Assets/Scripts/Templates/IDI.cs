using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this template needs
// the animator that will activate the desired change in the map
// a function that will play that animation that can be called from the CDI script

public class IDI : MonoBehaviour
{
    // public Animator anim;

 // Use this for initialization
    void Start () 
    {
        // anim = GetComponent<Animator>();
    }
 
 // Update is called once per frame
    void Update () 
    {

    }

    public void animatorFunction()
    {
        // anim.Play("playAnimatorScript");
    }
}

