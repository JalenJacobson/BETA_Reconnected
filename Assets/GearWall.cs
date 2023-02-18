using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearWall : MonoBehaviour
{
    public GameObject touching;

    // void OnTriggerStay(Collider other)
    // {
    //     if(other.name.Contains("TriggerCube"))
    //     {
    //          touching = other.gameObject;
    //          touching.SendMessage("setGearWall", true);
    //          print("AAAA THIS WORKED");
    //     }
    // }
    
    // void OnTriggerExit(Collider other)
    // {
    //     if(other.name.Contains("TriggerCube"))
    //     {
    //          touching = other.gameObject;
    //          touching.SendMessage("wallInteraction", true);
    //     }
    // }
}
