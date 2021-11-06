using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act1Script : MonoBehaviour
{
   public GameObject Activate1;
   public Animator anim;
    // public bool displayBubble = false;
    public GameObject touching = null;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
    void Update()
    {

    }
    

   public void activate1()
   {
       anim.Play("Act1Anim");
   }
   public void activate1Stop()
   {
       anim.Play("Act1End");
   }
   
}
