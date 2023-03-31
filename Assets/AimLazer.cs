using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLazer : MonoBehaviour
{
    public GameObject YRotator;
    public GameObject XRotator;
    public Rigidbody RB_YRotator;
    public Rigidbody RB_XRotator;
    Vector3 m_EulerAngleVelocity;
    public float followTimeDelta = 8;
    public GameObject target;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        RB_YRotator = YRotator.GetComponent<Rigidbody>();
        RB_XRotator = XRotator.GetComponent<Rigidbody>();
        // m_EulerAngleVelocity = new Vector3(0, 0, rotateSpeed);

        //Set the angular velocity of the Rigidbody (rotating around the Y axis, 100 deg/sec)

        // StartCoroutine(spinLazer());
    }



    void FixedUpdate()
    {
      YRotator.transform.rotation = Quaternion.Slerp(YRotator.transform.rotation, Quaternion.LookRotation( target.transform.position - YRotator.transform.position ), followTimeDelta * 2 ); 
      XRotator.transform.rotation = Quaternion.Slerp(XRotator.transform.rotation, Quaternion.LookRotation( target.transform.position - XRotator.transform.position ), followTimeDelta * 2 ); 
      print(YRotator.transform.rotation);
        // Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        // m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation); 
    }

  //   public IEnumerator spinLazer()
  // {
  //   // yield return new WaitForSeconds(4);
  //   // rotateSpeed = 2; 
  //   // yield return new WaitForSeconds(4);
  //   // rotateSpeed = 0;
  //   //stop turining
  // }
}
