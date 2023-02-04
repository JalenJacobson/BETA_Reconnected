using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectToken : MonoBehaviour
{
    public GameObject Doors;
    public Doors Doors_script;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Doors = GameObject.FindGameObjectWithTag("Gate");
        Doors_script = Doors.GetComponent<Doors>();
        anim = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
      if(other.name == "Gears" || other.name == "Brute" || other.name == "IdleLuz" || other.name == "Pump" || other.name == "SatBot")
      {
        anim.Play("TokenCollected");
        Doors_script.CollectToken();
      }   
    } 
}
