using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityRoom : MonoBehaviour
{

     void OnTriggerStay(Collider other)
     {
         var characterName = other.name;
         print(characterName);
         if(characterName == "Brute" || characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump"){
             other.gameObject.SendMessage("highGravityEnter"); 
         }
            
     }
     void OnTriggerExit(Collider other)
     {
         var characterName = other.name;
        print(characterName);
        if(characterName == "Brute" || characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump"){
             other.gameObject.SendMessage("highGravityExit"); 
         }     
     }
 }
 
     
 
     
 