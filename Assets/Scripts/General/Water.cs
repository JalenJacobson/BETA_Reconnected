using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{



    void Start()
    {



    }

    void OnTriggerEnter(Collider other)
    {
    }

    void OnTriggerStay(Collider other)
    {
       var characterName = other.name;
        // print(characterName);
        if(characterName == "Brute" || characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot")
        {
            other.gameObject.SendMessage("waterEnter"); 



        }
    }

     void OnTriggerExit(Collider other)
     {
        var characterName = other.name;
        print(characterName);
        if(characterName == "Brute" || characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot")
        {
            other.gameObject.SendMessage("waterExit");



        }
     }
}
