using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftStopper : MonoBehaviour
{
    public GameObject Lifter;
    public Lifter LuzLifter_script;
    // Start is called before the first frame update
    void Start()
    {
        LuzLifter_script = Lifter.GetComponent<Lifter>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "LiftStopper")
        {
          LuzLifter_script.Float();
        } 
    }
    void OnTriggerExit(Collider other)
    {
        if(other.name == "LiftStopper")
        {
          LuzLifter_script.Float();
        } 
    }
}
