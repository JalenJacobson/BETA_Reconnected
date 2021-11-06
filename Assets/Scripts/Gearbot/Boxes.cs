using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
   public Animator anim;

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
 void Update () {
        if (Input.GetKeyDown("h"))
        {
            anim.Play("LiftBoxes");

        }
    }

    public void Activate()
    {
        anim.Play("LiftBoxes");
    }
}