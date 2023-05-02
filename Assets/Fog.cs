using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.name == "Gears" || other.name == "Brute" || other.name == "IdleLuz" || other.name == "Pump" || other.name == "SatBot" || other.name.Contains("Mine"))
        {
            other.gameObject.SendMessage("bigLazerdmg");
        }
    } 
}
