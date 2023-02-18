using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearWall : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("GearTriggerCube"))
        {
             var touching = other.gameObject;
             touching.SendMessage("setGearWall", true);
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if(other.name.Contains("GearTriggerCube"))
        {
             var touching = other.gameObject;
             touching.SendMessage("wallInteraction", true);
        }
    }
}
