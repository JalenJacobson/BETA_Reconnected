using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifter : MonoBehaviour
{
   public Animator anim;

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
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
    }
}
