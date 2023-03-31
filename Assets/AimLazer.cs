using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLazer : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    Vector3 m_EulerAngleVelocity;
    public float rotateSpeed = 0;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, 0, rotateSpeed);

        //Set the angular velocity of the Rigidbody (rotating around the Y axis, 100 deg/sec)

        StartCoroutine(spinLazer());
    }



    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation); 
    }

    public IEnumerator spinLazer()
  {
    yield return new WaitForSeconds(4);
    rotateSpeed = 2; 
    yield return new WaitForSeconds(4);
    rotateSpeed = 0;
    //stop turining
  }
}
