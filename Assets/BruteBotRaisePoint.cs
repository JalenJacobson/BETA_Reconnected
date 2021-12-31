using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteBotRaisePoint : MonoBehaviour
{

    public GameObject touching = null;
    public float force = 20f;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
     anim = GetComponent<Animator>();   
    }

    void OnTriggerEnter(Collider other)
    {
        // var characterName = other.name;
        // print(characterName);
        if(other.name == "IdleLuz" || other.name == "Gears" || other.name == "SatBot" || other.name == "Pump")
        {
            print(other.name);
            if(touching == null)
            {
                touching = other.gameObject; 
            }  
        }
        anim.Play("BruteSpringLoad");
        
    }

    void OnTriggerExit(Collider other)
    {   
        if(other.name == "IdleLuz" || other.name == "Gears" || other.name == "SatBot" || other.name == "Pump")
        {   
            touching = null;
        }
    }

    public void Activate()
    {
        StartCoroutine(raiseBot(.60f));   
    }

    IEnumerator raiseBot(float time)
    {
        yield return new WaitForSeconds(time);
        var touchingRigidBody = touching.GetComponent<Rigidbody>();
        anim.Play("BruteSpring");
        touchingRigidBody.AddForce(transform.up * force);
    } 
}
