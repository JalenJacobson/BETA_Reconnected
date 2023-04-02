using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerTarget : MonoBehaviour
{
    public GameObject target;
    public float speed = 1.0f;
    private Transform targetPosition;

    void Start()
    {
        targetPosition = target.transform;
    }



    void Update() 
     {
        var step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, step);
     }

}
