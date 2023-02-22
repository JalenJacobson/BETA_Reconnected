using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifter : MonoBehaviour
{
    public Animator anim;
    public GameObject Stand;
    public Rigidbody Stand_Rigidbody;
    public float force = 20f;
    public Vector3 directionMove;
    public bool lifting = false;
    public bool floating = false;

    void Start () 
    {
        anim = GetComponent<Animator>();
        Stand_Rigidbody = Stand.GetComponent<Rigidbody>();
        directionMove = new Vector3(0, 20, 0);
        Stand_Rigidbody.isKinematic = false; 
    }
 
    void Update () 
    {  
        if(lifting && !floating)
        {
            anim.Play("Lifter");
            Stand_Rigidbody.velocity = directionMove;
            Stand_Rigidbody.isKinematic = false;
        }  
        else if(lifting && floating)
        {
            Stand_Rigidbody.isKinematic = true;
        }
        else if(!lifting)
        {
            Stand_Rigidbody.isKinematic = false;
            anim.Play("LifterIdle");
        }
    }

    public void Activate()
    {
        lifting = !lifting;
    }
    public void Float()
    {
        floating = !floating;
    }



    
}
