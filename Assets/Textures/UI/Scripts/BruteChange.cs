using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteChange : MonoBehaviour
{
   public Animator anim;

    

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
    public void Play()
    {
    anim.Play("BruteNameOn");
    }
    public void Stop()
    {
    anim.Play("BruteNameOff");
    }
}
