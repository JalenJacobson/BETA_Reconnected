using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearWallGears : MonoBehaviour
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
     public void OnTriggerEnter(Collider other)
    {
        if(other.name == "Gears")
        {
            anim.Play("GearWall");
        }
    } 
    public void OnTriggerExit(Collider other)
    {
        if(other.name == "Gears")
        {
            anim.Play("StopSpinning");
        }
    } 
}
