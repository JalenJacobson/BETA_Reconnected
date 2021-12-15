using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallWall : MonoBehaviour
{
public GameObject Wall;
   public Animator anim;

       void Start()
       {
        anim = GetComponent<Animator>();
       }
    void OnTriggerEnter(Collider other)
    {
        var characterName = other.name;
        if(characterName == "Brute" || characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump")
        {
             anim.Play("FallWall"); 
        }
    }
              
}
 
