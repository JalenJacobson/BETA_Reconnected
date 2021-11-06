using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteSelect : HeroSelectPlayer
{
    public GameObject BruteSelectButton;
    public GameObject Brute;
   public Animator anim;
    // public bool displayBubble = false;
    public GameObject touching = null;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
        name = "Brute";
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
            bruteUp();
        }
        else if(isUp && !isSelected)
        {
            bruteDown();
        }
    }
    
   public void Up()
   {
        anim.Play("BruteSelectUp");
        
   }
   public void Down()
   {
       anim.Play("BruteSelectDown");

   }
    public void toggleSelect()
    {
        isLocalPlayer = !isLocalPlayer;
        isSelected = !isSelected;
        sendState();
    }

    public void bruteUp()
    {
        isUp = true;
        anim.Play("BruteUp");
    }

    public void bruteDown()
    {
        isUp = false;
        anim.Play("BruteStart");
    }
}
   
