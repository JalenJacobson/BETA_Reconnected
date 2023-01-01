using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public bool RotatorConnected = false;
    public float rotateSpeed = 2;
    public string moveAxisHorizontal;
    public Vector3 direction;
    

    void Awake()
    {
        moveAxisHorizontal = PlayerPrefs.GetString("GearAxisHorizontal");
    }

    void Update()
    {
        if(RotatorConnected)
        {
            Movement();
        }
    }

    public void Movement(float x, float y)
    {
        
        if (x != 0)
        {
            transform.Rotate(0, x * rotateSpeed, 0, Space.World);   
        }
    }
}
