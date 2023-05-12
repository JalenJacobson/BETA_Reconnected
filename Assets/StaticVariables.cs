using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    public static string saveSlot = "Slot1";
    // Start is called before the first frame update
    void Start()
    {
       saveSlot = "Slot1"; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
