using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpTorch : MonoBehaviour
{
    public bool lit = false;
    public GameObject Fire;
    public ParticleSystem fire;
    public GameObject Smoke;
    public ParticleSystem smoke;
    // Start is called before the first frame update
    void Start()
    {
     fire = Fire.GetComponent<ParticleSystem>(); 
     smoke = Smoke.GetComponent<ParticleSystem>(); 
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "fire" && lit == false)
        {
          lit = true;
          fire.Play();
          smoke.Play();
        } 
    }

}
