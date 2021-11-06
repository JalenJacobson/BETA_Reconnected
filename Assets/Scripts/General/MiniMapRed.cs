using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapRed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
 GetComponent<MeshRenderer>().enabled = true;       
    }
    void OnTriggerEnter(Collider other)
    {
    var characterName = other.name;
    if(characterName == "Brute" || characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump"){
    
 GetComponent<MeshRenderer>().enabled = false;
    }
    }

}