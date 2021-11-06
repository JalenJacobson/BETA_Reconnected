using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzSelect : HeroSelectPlayer
{
    public GameObject LuzSelectButton;
    public GameObject Luz;
   public Animator anim;
    // public bool displayBubble = false;
    public GameObject touching = null;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
        name = "Luz";
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
            luzUp();
        }
        else if(isUp && !isSelected)
        {
            luzDown();
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
   
