using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBlow : MonoBehaviour
{
    public float force = 20f;
    public GameObject touching = null;

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "IdleLuz" || other.name == "Gears" || other.name == "SatBot" || other.name == "Brute" || other.name.Contains("Push"))
        {
            print(other.name);
            if(touching == null)
            {
                touching = other.gameObject; 
            }  
        }
    }

    void OnTriggerStay(Collider other)
    {
        var touchingRigidBody = touching.GetComponent<Rigidbody>();
        print(transform.up * force);
        touchingRigidBody.AddForce(transform.up * force);
    }
}
