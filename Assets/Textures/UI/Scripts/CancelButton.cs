using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelButton : MonoBehaviour
{
   public GameObject Cancel;
   public Animator anim;
    // public bool displayBubble = false;
    public GameObject touching = null;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
    void Update()
    {

    }
    

   public void CancelStart()
   {
       anim.Play("CancelAnim");
   }
   public void CancelStop()
   {
       anim.Play("CancelEnd");
   }
   
}
