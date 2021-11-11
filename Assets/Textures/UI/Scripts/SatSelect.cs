using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatSelect : HeroSelectPlayer
{
    public GameObject SatSelectButton;
    public GameObject SatBot;
   public Animator anim;
    // public bool displayBubble = false;
    public GameObject touching = null;

    // public GameObject Level_Manager;
    // public Level_Manager Level_Manager_Script;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
        name = "Sat";
        isUp = false;
        isLocalPlayer = false;
        isSelected = false;
        sendState();
        // Level_Manager_Script = Level_Manager.GetComponent<Level_Manager>();
 }
 
 // Update is called once per frame
    void Update()
    {
        if(!isUp && isSelected)
        {
            satUp();
        }
        else if(isUp && !isSelected)
        {
            satDown();
        }
    }
    
   public void Up()
   {
       anim.Play("SatSelectUp");
       

   }
   public void Down()
   {
       anim.Play("SatSelectDown");

   }
      public void Up2()
   {
       anim.Play("SatSelectUp2");
       

   }
   public void Down2()
   {
       anim.Play("SatSelectDown2");

   }

    public void toggleSelect()
    {
        isLocalPlayer = !isLocalPlayer;
        isSelected = !isSelected;
        sendState();
    }

    public void satUp()
    {
        isUp = true;
        anim.Play("SatUp");
    }

    public void satDown()
    {
        isUp = false;
        anim.Play("SatDown");
    }
}
   
