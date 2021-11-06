using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueWall : MonoBehaviour
{
   public Animator anim;

    

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
     void OnTriggerEnter(Collider other)
     {

    
     }

    void OnTriggerStay(Collider other)
    {

    }

     void OnTriggerExit(Collider other)
     {
  // anim.Play("BlueWallClose");
     }
 
 // Update is called once per frame
    public void Play()
    {
      anim.Play("BlueWallOpen");
    }
    public void Stop()
    {
      anim.Play("BlueWallClose");
    }
}
