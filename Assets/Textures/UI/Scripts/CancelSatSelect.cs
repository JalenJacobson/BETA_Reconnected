using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelSatSelect : MonoBehaviour
{
    public GameObject CancelButton;
    public GameObject SatBot;
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
    
   public void Up()
   {
       anim.Play("CancelUp");

   }
   public void Down()
   {
       anim.Play("CancelDown");

   }
      public void Select()
   {
       anim.Play("SatDown");

   }
}
   
