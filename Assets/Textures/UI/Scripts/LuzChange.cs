using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzChange : MonoBehaviour
{
   public Animator anim;

    

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
    public void Play()
    {
  anim.Play("LuzNameOn");
    }
    public void Stop()
    {
  anim.Play("LuzNameOff");
    }
}