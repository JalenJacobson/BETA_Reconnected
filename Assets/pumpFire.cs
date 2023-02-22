using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpFire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
  {
    // if(!fireActive) return;
    if(other.name.Contains("Gear") || other.name.Contains("Brute") || other.name.Contains("Luz") || other.name.Contains("Pump") || other.name.Contains("Sat"))
    {
        other.gameObject.SendMessage("death");
    }
    
  } 
}
