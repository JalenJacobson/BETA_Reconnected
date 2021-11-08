using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearConnection_Claw : MonoBehaviour
{

    public GameObject Claw;
    public Claw ClawMove_Script;
    public GameObject ClawBoundries;
    public ClawBoundries ClawBoundry_Script;
    // Start is called before the first frame update
    void Start()
    {
        ClawMove_Script = Claw.GetComponent<Claw>();
        ClawBoundry_Script = ClawBoundries.GetComponent<ClawBoundries>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Activate()
    {
        ClawMove_Script.Activate();
        ClawBoundry_Script.Activate();
    }

    public void toggleClawConnected()
    {
        ClawMove_Script.clawConnected = !ClawMove_Script.clawConnected;
        ClawBoundry_Script.clawConnected = !ClawBoundry_Script.clawConnected;
    }
}
