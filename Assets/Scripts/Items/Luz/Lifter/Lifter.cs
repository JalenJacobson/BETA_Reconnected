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

    void Start () 
    {
        anim = GetComponent<Animator>();
        Stand_Rigidbody = Stand.GetComponent<Rigidbody>(); 
    }
 
    void Update () 
    {  
        if(lifting)
        {
            directionMove = new Vector3(0, 10, 0);
            Stand_Rigidbody.velocity = directionMove;
        }  
    }

    public void Activate()
    {
        anim.Play("Lifter");
        lifting = !lifting;
    }
}
