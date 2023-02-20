using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarLightBulb : MonoBehaviour
{
   public Slider slider;
   public Image fill;
   public float chargeTime = 10f;
    // public bool displayBubble = false;
    //public GameObject touching = null;


 // Use this for initialization
 void Start () 
 {
        
 }
 
 // Update is called once per frame
    void Update()
    {
        slider.value = chargeTime;
        chargeTime -= Time.deltaTime;
    }

    public void rechargeBulb()
    {

    }
}
