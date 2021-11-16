using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors_BotConnection_Base : MonoBehaviour
{

    public GameObject Doors;
    public Doors Doors_script;
    public Animator anim;
    private bool alreadyActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        Doors_script = Doors.GetComponent<Doors>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        if(!alreadyActivated)
        {
            alreadyActivated = true;
            Doors_script.Activate();
            anim.Play("ButtonActive");
            anim.Play("PumpActivate");
            anim.Play("SatDoorActivate");
        }
    }
}
