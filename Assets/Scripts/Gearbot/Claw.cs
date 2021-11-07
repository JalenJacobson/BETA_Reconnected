using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour
{

   public Animator anim;
   public float speed;
   public Transform target;
   public Transform target2;
   public Transform target3;
   public Transform target4;
   public Transform target5;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }


 
 // Update is called once per frame
 void Update () {
        if (Input.GetKeyDown("v"))

        {
            anim.Play("Claw");

        }
        if (Input.GetKeyDown("b"))
        {
            anim.Play("Open");

        }
         if (Input.GetKeyDown("n"))
        {
            anim.Play("ClawClose");
        }
                float step = speed * Time.deltaTime;
        if (Input.GetKey("i")){
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);  
        }
        if (Input.GetKey("j")){
            transform.position = Vector3.MoveTowards(transform.position, target2.position, step);  
        }      
        if (Input.GetKey("k")){
            transform.position = Vector3.MoveTowards(transform.position, target3.position, step);  
        }   
        if (Input.GetKey("l")){
            transform.position = Vector3.MoveTowards(transform.position, target4.position, step);
        }    
        //if (Input.GetKeyUp("v")){
        //    transform.position = Vector3.MoveTowards(transform.position, target5.position, step);   
       // }  
    }
 }

    // public void changeGearBox2()
    // {
    //     print("worked");
    //     gearBox2 = !gearBox2; 
    // }
