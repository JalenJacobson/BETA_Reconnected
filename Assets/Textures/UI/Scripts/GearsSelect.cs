using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearsSelect : HeroSelectPlayer
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
       anim.Play("GearsSelectUp");
       

   }
   public void Down()
   {
       anim.Play("GearsSelectDown");

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
        anim.Play("GearUp");
    }

    public void gearsDown()
    {
        isUp = false;
        anim.Play("GearDown");
    }
}
   
