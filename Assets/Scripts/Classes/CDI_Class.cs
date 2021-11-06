using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDI_Class : MonoBehaviour
{
    public Animator anim;
    // public float pos = 0;
    // public GameObject GateDoors;
    // Doors doorsOpen_script;
    // public GameObject GateGearObj;
    // GateGear gategearactivate_script;
    // public AudioSource mySound;
    public string message;
    public Color orangeGravityField;
    public Color greenConsole;
    public Color blueCircuitField;
    public Color redDanger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public virtual void Activate(Text errMessage)
    {
        // pos = 1; 
        // doorsOpen_script.changeGearBox1();
        // gategearactivate_script.changeGearBox1();
        // anim.Play("GearTrigger");
        // mySound.Play();
        // errMessage.text = message;
    }
}
