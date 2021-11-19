using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActive : MonoBehaviour
{
    public bool activeFlame = true;

    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
      var characterName = other.name;
      if(characterName == "IdleLuz" || characterName == "SatBot" || characterName == "Pump" || characterName == "Brute" || characterName == "Gears")
      {
        if(activeFlame == true)
        {
          other.gameObject.SendMessage("returnToStart");
        }
        
      }

    }
}
