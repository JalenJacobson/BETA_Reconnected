using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSelect : MonoBehaviour
{
    public GameObject BotSelectButton;
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
    

   public void Stop()
   {
       anim.Play("BotSelectDown");

   }
      public void Stop2()
   {
       anim.Play("BotSelectDownP2");

   }
    public void Initiate()
   {
       anim.Play("BotSelectUp");

   }
       public void Initiate2()
   {
       anim.Play("BotSelectUpP2");
   }
          public void TutorialInfo()
   {
       anim.Play("TutorialInfo");
   }
             public void TurnOffInfo()
   {
       anim.Play("TurnOffInfo");
   }
}
   
