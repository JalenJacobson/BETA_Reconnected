using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatBotAnim : MonoBehaviour
{

    public GameObject Rails;
    public Animator anim;
    void Start()
    {
    anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    public void rails()
    {
    anim.Play("MoveSat");    
    }
}
