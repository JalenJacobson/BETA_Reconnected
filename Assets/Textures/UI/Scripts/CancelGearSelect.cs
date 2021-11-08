using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelGearSelect : MonoBehaviour
{
    public GameObject CancelButton;
    public GameObject Gears;
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
       anim.Play("GearDown");

   }
      public void Up2()
   {
       anim.Play("CancelUp2");

   }
   public void Down2()
   {
       anim.Play("CancelDown2");

   }
      public void Select2()
   {
       anim.Play("GearDown2");

   }
}
   
