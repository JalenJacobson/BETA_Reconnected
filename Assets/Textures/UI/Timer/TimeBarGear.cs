using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBarGear : MonoBehaviour
{
   public GameObject TimerBarGear;
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
    

   public void timerStart()
   {
       anim.Play("Timer");
   }
   public void timerStop()
   {
       anim.Play("NonEnterIdle");
   }
      public void enterbluewall()
   {
       print("entered blue wall");
       anim.Play("EnterBlueWall");
   }
    public void exitbluewall()
   {
       anim.Play("Timer");
   }
   
}
