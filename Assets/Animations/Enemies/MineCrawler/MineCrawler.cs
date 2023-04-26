using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCrawler : MonoBehaviour
{
    public Animator anim;
    public bool isBeingCarried;
    public bool Explode;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
  
    }
    void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("Floor"))
        {
            onGround();
        }
        else if(other.name.Contains("Gear") || other.name.Contains("Brute") || other.name.Contains("Luz") || other.name.Contains("Pump") || other.name.Contains("Sat") || other.name.Contains("Hole"))
        {
            anim.Play("BlowUp");
        }
    }

    void OnTriggerExit(Collider other)
    {

    }

    public void onGround()
    {
        anim.Play("Dig");
    }
    public void inAir()
    {
        anim.Play("Scramble");
    }
    public void Lazerdmg()
    {
        anim.Play("BlowUp");
    }
    public void bigLazerdmg()
    {
        anim.Play("BlowUp");
    }


}
