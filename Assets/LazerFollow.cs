using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerFollow : MonoBehaviour
{

    public GameObject target;
    public float speed = 1.0f;
    private Transform targetPosition;
    public Rigidbody rb;
    public Vector3 directionMove;
    public float moveSpeed = 10;
    public bool killMode = true;
    private Vector3 scaleChange;

    void Start()
    {
         scaleChange = new Vector3(2.5f, 2.5f, 2.5f);
    }



    void Update() 
     {
        targetPosition = target.transform;
        var step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, step);
     }

    public void Movement(float x, float y)
    {
        directionMove = new Vector3(x * moveSpeed, rb.velocity.y, y * moveSpeed);
        rb.velocity = directionMove;
    }

    public void OnTriggerStay(Collider other)
    {

      if(other.name == "Gears" || other.name == "Brute" || other.name == "IdleLuz" || other.name == "Pump" || other.name == "SatBot" || other.name.Contains("Mine"))
      {
        if(killMode == false)
        {
            other.gameObject.SendMessage("Lazerdmg");
        }
        else if(killMode == true)
        {
            other.gameObject.SendMessage("bigLazerdmg");
        }
        
      }
    
    } 

    public void Slow()
    {
        speed = 5f;
        killMode = false;
        scaleChange = new Vector3(0.5f, 0.5f, 0.5f);
    }
    public void Slow2()
    {
        speed = 7f;
        killMode = false;
        scaleChange = new Vector3(0.5f, 0.5f, 0.5f);
    }
    public void Fast()
    {
        speed = 40f;
        killMode = true;
        scaleChange = new Vector3(2.5f, 2.5f, 2.5f);
    }

}
