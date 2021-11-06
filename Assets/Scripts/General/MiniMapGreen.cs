using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapGreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
 GetComponent<MeshRenderer>().enabled = false;       
    }
    void OnTriggerEnter(Collider other)
    {
    var characterName = other.name;
    if(characterName == "Brute" || characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump"){
    
 GetComponent<MeshRenderer>().enabled = true;
    }
    }

}
