using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownloadBubbleScript : MonoBehaviour
{
   public GameObject ActionCircles;
   public GameObject ActionLight;
   public GameObject ActionDownload;
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
    

   public void actionBubbleStart()
   {
       anim.Play("ActionLightAnim");
       anim.Play("ActionCirclesAnim");
       anim.Play("ActionDownloadAnim");
       print("start");
   }
   public void actionBubbleStop()
   {
       anim.Play("ActionLightStop");
       anim.Play("ActionCirclesStop");
        anim.Play("ActionDownloadClose");
       print("actionBubbleStop");
   }
   
}
