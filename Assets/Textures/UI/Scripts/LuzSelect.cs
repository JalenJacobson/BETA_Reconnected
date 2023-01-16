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
        
 }
 
 // Update is called once per frame
    void Update()
    {
        
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
   
