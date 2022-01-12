using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoseConnections : MonoBehaviour
{
    public bool connected = false;
    public Rigidbody rb;
    public Transform target;
    public float speed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (connected == false)
        {
           // transform.position = Vector3.MoveTowards(transform.position, target.position, step);
           // transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, step);
        }
        
    }
    public void Connected()
    {
        connected = true;
    }
    public void SnapBack()
    {
        float step = speed * Time.deltaTime;
        connected = false;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, step);
    }
}
