using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroselectLight : MonoBehaviour
{
    public GameObject Lights;
   public Animator anim;
    // public bool displayBubble = false;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
    void Update()
    {

    }
    

   public void lights()
   {
       anim.Play("HeroSelectLights");
   }
   
}