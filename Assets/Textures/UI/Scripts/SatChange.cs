using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatChange : MonoBehaviour
{
   public Animator anim;

    

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
    public void Play()
    {
  anim.Play("SatNameOn");
    }
    public void Stop()
    {
  anim.Play("SatNameOff");
    }
}
