using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBubble : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
     {
         var characterName = other.name;
         print(characterName);
         if(characterName == "Brute" || characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot"){
             other.gameObject.SendMessage("pumpAirBubbleEnter"); 
         }
            
     }
     void OnTriggerExit(Collider other)
     {
         var characterName = other.name;
        print(characterName);
        if(characterName == "Brute" || characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot"){
             other.gameObject.SendMessage("pumpAirBubbleExit"); 
         }     
     }
}
