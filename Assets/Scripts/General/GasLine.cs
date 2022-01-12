using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasLine : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Pump"))
        {
            anim.Play("GasLineShow");
        }           
    }
            void OnTriggerExit(Collider other)
    {
        if(other.name.Contains("Pump"))
        {
            anim.Play("GasLineOff");
        }           
    }
}
