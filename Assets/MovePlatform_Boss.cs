using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform_Boss : MonoBehaviour
{
    public Animator anim;
    public bool down = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(down == true)
        {
            anim.Play("SS_Green");
        }
        else if(down == false)
        {
            anim.Play("SS_Red");
        }
    }

    public void Change()
    {
        down = !down;
    }

}
