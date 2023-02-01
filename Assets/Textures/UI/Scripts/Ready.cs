using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ready : MonoBehaviour
{
    //public GameObject ReadyButton;
   public Animator anim;
    // public bool displayBubble = false;
    //public GameObject touching = null;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
    void Update()
    {

    }
    

   public void ReadyStart()
   {
       anim.Play("Ready");

   }
      public void ReadyStop()
   {
       anim.Play("NotReady");

   }
         public void Cancel()
   {
       anim.Play("CancelReadyTutorial");

   }
         public void Initiate()
   {
       anim.Play("InitiateReadyButton");

   }
}
   
