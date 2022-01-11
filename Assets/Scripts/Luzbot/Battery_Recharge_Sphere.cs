using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_Recharge_Sphere : MonoBehaviour
{
    public GameObject touching;
    public List<GameObject> touchingBots;

    void OnTriggerEnter(Collider other)
    {
        var characterName = other.name;
        if(characterName == "Brute" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump" || characterName == "IdleLuz")
        {
            touchingBots.Add(other.gameObject);
        }
        
    }

     void OnTriggerExit(Collider other)
     { 
        var characterName = other.name;    
        if(characterName == "Brute" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump" || characterName == "IdleLuz")
        {   
                touchingBots.Remove(other.gameObject);
        }
     }

    public void Update()
    {
        if(touchingBots.Count > 0)
        {
            foreach (var bot in touchingBots)
            {
                bot.SendMessage("restoreHealth");
                touchingBots.Remove(bot);
                bot.SendMessage("HealBattery");
            }
        }
    }
}
