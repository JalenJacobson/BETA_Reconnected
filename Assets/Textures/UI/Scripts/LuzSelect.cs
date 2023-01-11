using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuzSelect : HeroSelectPlayer
{
    public GameObject LuzSelectButton;
    public GameObject Luz;
   public Animator anim;
    // public bool displayBubble = false;
    public GameObject touching = null;
    public Image P1Circle;

    // public GameObject Level_Manager;
    // public Level_Manager Level_Manager_Script;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
        name = "Luz";
        isUp = false;
        isLocalPlayer = false;
        isSelected = false;
        sendState();
        // Level_Manager_Script = Level_Manager.GetComponent<Level_Manager>();
 }
 
 // Update is called once per frame
    void Update()
    {
        // if(!isUp && isSelected)
        // {
        //     luzUp();
        // }
        // else if(isUp && !isSelected)
        // {
        //     luzDown();
        // }
        if(available == true)
        {
            P1Circle.enabled = false;
        }
        else if(available == false)
        {
            P1Circle.enabled = true;
        }
    }
    
   public void Up()
   {
        anim.Play("LuzSelectUp");
        
   }
   public void Down()
   {
       anim.Play("LuzSelectDown");

   }
      public void Up2()
   {
        anim.Play("LuzSelectUp2");
        
   }
   public void Down2()
   {
       anim.Play("LuzSelectDown2");

   }

    public void toggleSelect()
    {
        isLocalPlayer = !isLocalPlayer;
        isSelected = !isSelected;
        sendState();
    }

    public void luzUp()
    {
        isUp = true;
        anim.Play("LuzUp");
    }

    public void luzDown()
    {
        isUp = false;
        anim.Play("LuzStart");
    }
}
   
