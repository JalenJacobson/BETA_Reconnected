using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrain : MonoBehaviour
{
    public float drainTimeDelta = 30f;
    public Vector3 waterDrainLocation;
    public GameObject water;
    public bool waterDrainActive = false;
    public bool alreadyDraining = false;
    public GameObject targetWaterDrain;
 // Use this for initialization
    void Start () 
    {
       
    }
 
 // Update is called once per frame
    void Update () 
    {
        if(waterDrainActive)
        {
            print(waterDrainLocation.x);
            print(waterDrainLocation.y);
            print(waterDrainLocation.z);
            water.transform.position = Vector3.MoveTowards(water.transform.position, targetWaterDrain.transform.position, drainTimeDelta);
        }
    }

    public void Activate()
    {
        waterDrainActive = true;
    }
    
    public void refillWater()
    {
        
    }
}