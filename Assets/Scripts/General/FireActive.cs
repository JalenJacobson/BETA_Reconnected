using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActive : MonoBehaviour
{
    public bool activeFlame = true;

    void OnTriggerEnter(Collider other)
    {
      var characterName = other.name;
      if(characterName == "IdleLuz" || characterName == "SatBot" || characterName == "Pump" || characterName == "Brute")
      {
        if(activeFlame == true)
        {
          other.gameObject.SendMessage("returnToStart");
        }
        
      }
      else if(characterName == "Gears")
      {
        activeFlame = false;
        // put half flame animation here
      }
    }

    void OnTriggerExit(Collider other)
    {
      var characterName = other.name;
      if(characterName == "Gears")
      {
        activeFlame = true;
        // put fireIdle animation here
      }
    }
}
