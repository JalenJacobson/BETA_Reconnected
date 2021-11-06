using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMoverStandScript : MonoBehaviour
{
public GameObject GearMoverStand;
public Animator anim;
    
      void Start()
    {
        anim = GetComponent<Animator>();

    }  
    
    public void lift()
    {
      anim.Play("GearStandLift");        
    }
    public virtual void moveleft()
    {
      anim.Play("MoveLeft");
    } 
    public virtual void moveright(){
      anim.Play("MoveRight");
    }    
    
        public void down()
    {
  anim.Play("GearStandFall");        
    }
  

    // Update is called once per frame

}
