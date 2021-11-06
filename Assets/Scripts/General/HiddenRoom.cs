using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
 GetComponent<MeshRenderer>().enabled = true;       
    }
    void OnTriggerStay(Collider other)
    {
    var characterName = other.name;
    if(characterName == "Brute" || characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump"){
    
 GetComponent<MeshRenderer>().enabled = false;
    }
    }
        void OnTriggerExit(Collider other)
    {
GetComponent<MeshRenderer>().enabled = true;        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
