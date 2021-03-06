using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearsSelect2 : HeroSelectPlayer
{
    public GameObject GearsSelectButton;
    public GameObject Gears;
   public Animator anim;
    // public bool displayBubble = false;
    public GameObject touching = null;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
        name = "Gears";
        isUp = false;
        isLocalPlayer = false;
        isSelected = false;
        sendState();
 }
 
 // Update is called once per frame
    void Update()
    {
        if(!isUp && isSelected)
        {
            gearsUp();
        }
        else if(isUp && !isSelected)
        {
            gearsDown();
        }
    }
    
   public void Up()
   {
       anim.Play("GearsSelectUp2");
       

   }
   public void Down()
   {
       anim.Play("GearsSelectDown2");

   }
      public void Up2()
   {
       anim.Play("GearsSelectUp2");
       

   }
   public void Down2()
   {
       anim.Play("GearsSelectDown2");

   }

    public void toggleSelect()
    {
        isLocalPlayer = !isLocalPlayer;
        isSelected = !isSelected;
        sendState();
    }

    public void gearsUp()
    {
        isUp = true;
        anim.Play("GearUpP2");
    }

    public void gearsDown()
    {
        isUp = false;
        anim.Play("GearDown2");
    }
        public void gearsUp2()
    {
        isUp = true;
        anim.Play("GearUp2");
    }

    public void gearsDown2()
    {
        isUp = false;
        anim.Play("GearDown2");
    }
}
   
