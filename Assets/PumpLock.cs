using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpLock : MonoBehaviour
{
    public Animator anim;
    public int toOpen = 2;
    public int activated = 0;
    public GameObject[] spinners;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        spinners = GameObject.FindGameObjectsWithTag("Spinner");
         toOpen = spinners.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated >= toOpen)
        // if (GatePowerConnection1_script.active == true  && GateGearObj_script.active == true)
        {
            anim.Play("Unlock");
        }
    }
    public void Activate()
    {
        activated++;
    }
}
