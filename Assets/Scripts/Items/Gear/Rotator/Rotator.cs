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

    void Movement()
    {
        float horizontalMove = Input.GetAxis(moveAxisHorizontal);
        if (horizontalMove != 0)
        {
            transform.Rotate(0, horizontalMove * rotateSpeed, 0, Space.World);   
        }
    }
}
