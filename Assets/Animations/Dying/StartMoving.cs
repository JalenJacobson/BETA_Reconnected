using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMoving : MonoBehaviour
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
           void OnTriggerEnter(Collider other)
     {
    var characterName = other.name;
    if(characterName == "IdleLuz" || characterName == "SatBot" || characterName == "Pump" || characterName == "Brute" || characterName == "Gears")
        {     
            anim.Play("StartMoving");    
        }

     }
}
