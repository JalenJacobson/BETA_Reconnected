using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public bool RotatorConnected = false;
    public float rotateSpeed = 2;
    public string moveAxisHorizontal;
    public Vector3 direction;
    Rigidbody m_Rigidbody;
    Vector3 m_EulerAngleVelocity;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();        
    }

    void Update()
    {
        if(RotatorConnected)
        {
           // Movement();
        }
    }

    public void Movement(float x, float y)
    {
        
        // if (x != 0)
        // {
        //     transform.Rotate(0, x * rotateSpeed, 0, Space.World);   
        // }
        if (x != 0)
        {
            m_EulerAngleVelocity = new Vector3(0, x * rotateSpeed, 0); 
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation); 
        }
    }
}
