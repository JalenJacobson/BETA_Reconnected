using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveBruteW : MonoBehaviour {

   public Animator anim;

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
 void Update () {

    }

   public void Lift()
   {
        anim.Play("Push");
   }
      public void Drop()
   {
        anim.Play("BruteWalk");
   }
}