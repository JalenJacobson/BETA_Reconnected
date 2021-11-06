using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPump2 : MonoBehaviour
{
   public GameObject ActionCircles;
   public GameObject ActionLight;
    public GameObject Button6;
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
    

   public void actionBubble2Start()
   {
       anim.Play("ActionLightAnim");
       anim.Play("ActionCirclesAnim");
       anim.Play("ActionPump2Open");
       print("start");
   }
   public void actionBubble2Stop()
   {
       anim.Play("ActionLightStop");
       anim.Play("ActionCirclesStop");
        anim.Play("ActionPumpClose");
       print("actionBubbleStop");
   }
   
}
