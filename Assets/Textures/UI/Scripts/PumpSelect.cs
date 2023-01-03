using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpSelect : HeroSelectPlayer
{
    public GameObject PumpSelectButton;
    public GameObject Pump;
    public Animator anim;
    // public bool displayBubble = false;
    public GameObject touching = null;

    // public GameObject Level_Manager;
    // public Level_Manager Level_Manager_Script;

    


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
        name = "Pump";
        isUp = false;
        isLocalPlayer = false;
        isSelected = false;
        // Level_Manager_Script = Level_Manager.GetComponent<Level_Manager>();
 }
 
 // Update is called once per frame
    void Update()
    {
        if(!isUp && isSelected)
        {
            pumpUp();
        }
        else if(isUp && !isSelected)
        {
            pumpDown();
        }
    }
    
   public void Up()
   {
       anim.Play("PumpSelectUp");
       

   }
   public void Down()
   {
       anim.Play("PumpSelectDown");

   }
      public void Up2()
   {
       anim.Play("PumpSelectUp2");
       

   }
   public void Down2()
   {
       anim.Play("PumpSelectDown2");

   }

    public void toggleSelect()
    {
        isLocalPlayer = !isLocalPlayer;
        isSelected = !isSelected;
        sendState();
    }

    public void pumpUp()
    {
        isUp = true;
        anim.Play("PumpUp");
    }

    public void pumpDown()
    {
        isUp = false;
        anim.Play("PumpStart");
    }
}
   
