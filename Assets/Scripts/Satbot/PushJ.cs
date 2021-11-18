using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushJ : MonoBehaviour

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
        if(other.name.Contains("Sat"))
        {     
            anim.Play("ButtonC");    
        }
         else if(Input.GetKeyDown("j"))
         {
            anim.Play("ButtonV"); 
         }
         else if(Input.GetKeyDown("k"))
         {
            anim.Play("ButtonB"); 
         }
         else if(Input.GetKeyDown("l"))
         {
            anim.Play("Disconnected"); 
         } 

     }
            void OnTriggerStay(Collider other)
     {
         

     }
            void OnTriggerExit(Collider other)
     {
        if(other.name.Contains("Sat"))
        {     
            anim.Play("Disconnected");    
        }

     }

}
