using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMoverMove : MonoBehaviour
{
public GameObject GearMoverStand;
public float speed;
public GameObject GearMoverStandScript;
GearMoverStandScript gearmover_script;

public Transform target;
public Transform target2;
public bool gearBox2 = false;
    
      void Start()
    {
        gearmover_script = GearMoverStandScript.GetComponent<GearMoverStandScript>();
    }  
    
    public virtual void Update()
    {
        float step = speed * Time.deltaTime;
        if (gearBox2 == true){
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);  
        }
        if (gearBox2 == false){
            transform.position = Vector3.MoveTowards(transform.position, target2.position, step);  
        }      
    }    



        public void changeGearBox2()
    {
        print("worked");
        gearBox2 = !gearBox2; 
    }

    // Update is called once per frame

}
