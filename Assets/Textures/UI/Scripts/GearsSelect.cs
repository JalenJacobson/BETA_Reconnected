using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearsSelect : HeroSelectPlayer
{
    public GameObject GearsSelectButton;
    public GameObject Gears;
   public Animator anim;
    // public bool displayBubble = false;
    public GameObject touching = null;
    public Image P1Circle;
    
    // public GameObject Level_Manager;
    // public Level_Manager Level_Manager_Script;

    public int playerLevelValue = 1;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
        name = "Gears";
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
        //     gearsUp();
        // }
        // else if(isUp && !isSelected)
        // {
        //     gearsDown();
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
       anim.Play("GearsSelectUp");

   }
   public void Down()
   {
       anim.Play("GearsSelectDown");

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
        anim.Play("GearUp");
        // Level_Manager_Script.setLevelValue(playerLevelValue);
        // print(Level_Manager_Script.levelValue);
    }

    public void gearsDown()
    {
        isUp = false;
        anim.Play("GearDown");
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
   
