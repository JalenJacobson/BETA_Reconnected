using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTriggerBattery : MonoBehaviour
{
    public Animator anim;
    public GameObject Battery;
    public BatteryAnimator BatteryAnimator_Script;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        BatteryAnimator_Script = Battery.GetComponent<BatteryAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        void OnTriggerEnter(Collider other)
         {
            if(other.name.Contains("Sat") || other.name.Contains("IdleLuz") || other.name.Contains("Gear") || other.name.Contains("Pump") || other.name.Contains("Brute"))
            {
                BatteryAnimator_Script.canAnimate = true;
                anim.Play("UiButton");
            }
         }

    void OnTriggerExit(Collider other)
         {
            if(other.name.Contains("Sat") || other.name.Contains("IdleLuz") || other.name.Contains("Gear") || other.name.Contains("Pump") || other.name.Contains("Brute"))
            {
                BatteryAnimator_Script.canAnimate = false;
                anim.Play("UiButtonDown");
            }
         }

    public void Activate()
    {
        BatteryAnimator_Script.Activate();
    }
}
