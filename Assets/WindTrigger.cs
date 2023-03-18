using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTrigger : MonoBehaviour
{
    public GameObject touching;
    public float force = 20f;
    public List<GameObject> touchingBots;

    void Start()
    {
    
    }
    void Update()
    {
        foreach(GameObject bot in touchingBots)
        {
             var touchingRigidBody = bot.GetComponent<Rigidbody>();
             touchingRigidBody.AddForce(transform.up * force);
             
             //play particle effect here
        }
    }

    void OnTriggerEnter(Collider other)
    {
        var characterName = other.name;
        if(characterName == "Brute" || characterName == "Gears" || characterName == "SatBot" || characterName == "IdleLuz" || characterName.Contains("LightBulb") || characterName.Contains("Push"))
        {
            touchingBots.Add(other.gameObject);
        }
        
        
    }

     void OnTriggerExit(Collider other)
     { 
        var characterName = other.name;    
        if(characterName == "Brute" || characterName == "Gears" || characterName == "SatBot" || characterName == "IdleLuz" || characterName.Contains("LightBulb") || characterName.Contains("Push"))
        {   
                touchingBots.Remove(other.gameObject);
        }
     }


    public void Activate()
    {
        
        
    }
}