using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMoverGears : MonoBehaviour
{
public GameObject GearMoverBox;
public Animator anim;
public bool gearBox2 = false;
    
      void Start()
    {
        anim = GetComponent<Animator>();

    } 
         void OnTriggerEnter(Collider other)
     {
  anim.Play("Stop");
    
     } 
    
    public void Update()
    {
        if (gearBox2 == true){
  anim.Play("Forward");        
    }  
    
    {
        if (gearBox2 == false){
  anim.Play("Backward");        
    }
    }
    }
            public void changeGearBox2()
    {
        print("worked");
        gearBox2 = !gearBox2; 
    }

    // Update is called once per frame

}
