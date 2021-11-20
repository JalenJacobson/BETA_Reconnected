using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_Crawler_Mover_Zaxis : MonoBehaviour
{
    public GameObject touching = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //   anim.Play("Stop");
        print(other.name);
        if(other.name.Contains("Stand"))
        {
             touching = other.gameObject;
             touching.SendMessage("toggleZ");
        }
    
    } 
    void OnTriggerExit(Collider other)
    {
        //   anim.Play("Stop");
        print(other.name);
        if(other.name.Contains("Stand"))
        {
             touching = other.gameObject;
             touching.SendMessage("toggleZ");
        }
    
    } 
}
