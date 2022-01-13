using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpConnector : MonoBehaviour
{
    public GameObject PumpTriggerCube;
    public PumpTriggerCube PumpTrigger_Script;
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
    PumpTriggerCube = GameObject.Find("PumpTriggerCube");
    Pump = GameObject.Find("Pump");
    PumpTrigger_Script = PumpTriggerCube.GetComponent<PumpTriggerCube>();
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
            PumpTrigger_Script.connectedBox = true;
        }
        else if(connected != true)
        {
            Connector.transform.SetParent(Pump.transform);
            PumpTrigger_Script.connectedBox = false;
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
