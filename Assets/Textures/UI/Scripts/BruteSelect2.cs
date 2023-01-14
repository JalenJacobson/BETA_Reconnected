using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteSelect2 : HeroSelectPlayer
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
        anim.Play("BruteSelectUp2");
        
   }
   public void Down()
   {
       anim.Play("BruteSelectDown2");

   }
      public void Up2()
   {
        anim.Play("BruteSelectUp2");
        
   }
   public void Down2()
   {
       anim.Play("BruteSelectDown2");

   }
    public void toggleSelect()
    {
        isLocalPlayer = !isLocalPlayer;
        isSelected = !isSelected;
        
    }

    public void bruteUp()
    {
        isUp = true;
        anim.Play("BruteUp2");
    }

    public void bruteDown()
    {
        isUp = false;
        anim.Play("BruteStart2");
    }
        public void bruteUp2()
    {
        isUp = true;
        anim.Play("BruteUp2");
    }

    public void bruteDown2()
    {
        isUp = false;
        anim.Play("BruteStart2");
    }
}
   
