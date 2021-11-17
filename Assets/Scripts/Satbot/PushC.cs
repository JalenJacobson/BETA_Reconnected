using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushC : MonoBehaviour

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
        if(Input.GetKeyDown("c"))
         {
            anim.Play("PushV"); 
         }
        if(Input.GetKeyDown("v"))
         {
            anim.Play("PushB"); 
         } 
        if(Input.GetKeyDown("b"))
         {
            anim.Play("Disconnected"); 
         } 
    }
       void OnTriggerEnter(Collider other)
     {
        if(other.name.Contains("Download"))
        {     
            anim.Play("PushC");    
        }

     }

}
