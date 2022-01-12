using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpConnector : MonoBehaviour
{
    public GameObject Pump;
    public GameObject Connector;
    public bool connected = false;
    public GameObject touching = null;
    public float speed = 50.0f;
    public Transform target;
    // Start is called before the first frame update

    void Awake()
    {
    Connector = GameObject.Find("Connector");
    Pump = GameObject.Find("Pump");
    }
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        if(connected == true)
        {
            Connector.transform.SetParent(touching.transform);
        }
        else if(connected != true)
        {
            Connector.transform.SetParent(Pump.transform);
        }

        float step = speed * Time.deltaTime;
        if (connected == false){
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, step);
        }
        
    }

    public void Connect()
    {
        connected = true;
    }
    public void SnapHoseBack()
    {
        connected = false;
    }
}
