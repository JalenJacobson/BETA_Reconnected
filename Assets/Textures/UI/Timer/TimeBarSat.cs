using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarSat : MonoBehaviour
{
   //public GameObject TimerBarSat;
   //public Animator anim;
   public Slider slider;
   public Image fill;
    // public bool displayBubble = false;
    //public GameObject touching = null;


 // Use this for initialization
 void Start () {
        
 }
 
 // Update is called once per frame
    void Update()
    {

    }

    public void drowning(float breathRemaining)
    {
        slider.value = breathRemaining;
    }

   
   
}
