using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifter : MonoBehaviour
{
   public Animator anim;
   public GameObject Stand;
   public Rigidbody Stand_Rigidbody;
   public float force = 20f;

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
        Stand_Rigidbody = Stand.GetComponent<Rigidbody>(); 
 }
 
 // Update is called once per frame
 void Update () {
        if (Input.GetKeyDown("g"))
        {
            anim.Play("Lifter");

        }
    }

    public void Activate()
    {
        anim.Play("Lifter");
        Stand_Rigidbody.AddForce(transform.up * force);
    }
}
