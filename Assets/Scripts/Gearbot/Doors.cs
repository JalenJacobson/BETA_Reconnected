using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
   public Animator anim;

//    public bool gearBox1 = false;
//    public bool gearBox2;
//    public bool powerConnection1 = false;
//    public bool powerConnection2 = false;

public GameObject GatePowerConnection1;
public GameObject GatePowerConnection2;
public GameObject GateGearObj;
public GameObject GateGearObj2;

public IDI_Base GatePowerConnection1_script;
public IDI_Base GatePowerConnection2_script;
public IDI_Base GateGearObj_script;
public IDI_Base GateGearObj2_script;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
        GatePowerConnection1_script = GatePowerConnection1.GetComponent<IDI_Base>();
        GatePowerConnection2_script = GatePowerConnection2.GetComponent<IDI_Base>();
        GateGearObj_script = GateGearObj.GetComponent<IDI_Base>();
        GateGearObj2_script = GateGearObj2.GetComponent<IDI_Base>();

 }
 
 // Update is called once per frame
 public virtual void Update () {
        if (GatePowerConnection1_script.active == true && GatePowerConnection2_script.active == true && GateGearObj_script.active == true && GateGearObj2_script.active == true)
        // if (GatePowerConnection1_script.active == true  && GateGearObj_script.active == true)
        {
            anim.Play("Doors");

        }
    }

    // public void changeGearBox1()
    // {
    //     print("worked");
    //     gearBox1 = !gearBox1; 
    // }
    // public void changeGearBox2()
    // {
    //     print("worked");
    //     gearBox2 = !gearBox2; 
    // }
    
    // public void changePowerConnection1()
    // {
    //     powerConnection1 = !powerConnection1; 
    // }
    // public void changePowerConnection2()
    // {
    //     powerConnection2 = !powerConnection2; 
    // }
}
