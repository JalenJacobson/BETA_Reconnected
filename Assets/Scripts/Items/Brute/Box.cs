using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Vector3 boxPos;


    // public Vector3 boxFallLocation;
    // public float boxFallTimeDelta = 30f;
    
    void Awake()
    {

    }
    
    void Start()
    {
        boxPos = transform.position;
    }

    public void death()
    {
        StartCoroutine(returnToStart());
    }

    public IEnumerator returnToStart()
    {
        yield return new WaitForSeconds(1);
        transform.position = boxPos;
    }

    public void boxFall()
    {

    }


}

