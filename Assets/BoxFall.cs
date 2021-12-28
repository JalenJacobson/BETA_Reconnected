using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        var characterName = other.name;
        if(characterName.Contains("Push"))
        {
          other.gameObject.GetComponent<Box>().boxFall();  
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
