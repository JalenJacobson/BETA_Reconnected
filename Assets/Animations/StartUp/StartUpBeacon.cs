using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpBeacon : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
         anim = GetComponent<Animator>();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Up()
   {
       anim.Play("BeaconUp");

   }
       public void Initiate2()
   {
       anim.Play("BeaconUp2");

   }
    public void Rotate()
    {
       anim.Play("Rotate");

    }
    public void Down()
   {
       anim.Play("BeaconDown");

   }
    public void Down2()
   {
       anim.Play("BeaconDown2");

   }
    public void Tutorial()
   {
       anim.Play("StartBeaconTutorial");

   }
}
