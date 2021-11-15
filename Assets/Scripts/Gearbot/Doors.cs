using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Animator anim;
    public int toOpen = 2;
    public int activated = 0;

    public GameObject[] Doors_Boxes;



 // Use this for initialization
    void Start () 
    {
        anim = GetComponent<Animator>();
        
        Doors_Boxes = GameObject.FindGameObjectsWithTag("Doors_Boxes");
        toOpen = Doors_Boxes.Length;
    }
 
 // Update is called once per frame
    public virtual void Update () 
    {
        if (activated >= toOpen)
        // if (GatePowerConnection1_script.active == true  && GateGearObj_script.active == true)
        {
            anim.Play("Doors");
        }
    }

    public void Activate()
    {
        activated++;
    }

    
}
