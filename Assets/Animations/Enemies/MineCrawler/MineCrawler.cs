using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCrawler : MonoBehaviour
{
    public Animator anim;
    public bool isBeingCarried;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isBeingCarried == true)
        {
            anim.Play("Scramble");            
            
        }   
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Floor"))
        {
            anim.Play("Dig");
        }
        if(other.name.Contains("Hole"))
        {
            anim.Play("Explode");
        }
    }

    void OnTriggerExit(Collider other)
         {
         }
    public void IsBeingCarried()
    {
        isBeingCarried = true;
    }
    public void isNotBeingCarried()
    {
        isBeingCarried = false;
    }

}
