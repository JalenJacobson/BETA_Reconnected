using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirVent : MonoBehaviour
{
    public GameObject touching;
    public float force = 20f;
    public List<GameObject> touchingBots;

    void OnTriggerEnter(Collider other)
    {
        var characterName = other.name;
        if(characterName == "Brute" || characterName == "Gears" || characterName == "SatBot" || characterName == "IdleLuz" || characterName.Contains("LightBulb"))
        {
            touchingBots.Add(other.gameObject);
        }
        
    }

     void OnTriggerExit(Collider other)
     { 
        var characterName = other.name;    
        if(characterName == "Brute" || characterName == "Gears" || characterName == "SatBot" || characterName == "IdleLuz" || characterName.Contains("LightBulb"))
        {   
                touchingBots.Remove(other.gameObject);
        }
     }


    public void Activate()
    {
        foreach(GameObject bot in touchingBots)
        {
             var touchingRigidBody = bot.GetComponent<Rigidbody>();
             touchingRigidBody.AddForce(transform.up * force);
             //play particle effect here
        }
        
    }
}
