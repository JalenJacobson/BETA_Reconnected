using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_Crawler_MoverXaxis : MonoBehaviour
{
    public GameObject touching = null;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (touching == true)
        {

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("d"))
             {
                 anim.Play("Forward");
             }

            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp("d"))
             {
                 anim.Play("Stop");
             }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown("a"))
             {
                 anim.Play("Backward");
             }

            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp("a"))
             {
                 anim.Play("Stop");
             }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //   anim.Play("Stop");
        print(other.name);
        if(other.name.Contains("Stand"))
        {
             touching = other.gameObject;
             touching.SendMessage("toggleX");



        }

    
    } 
    void OnTriggerExit(Collider other)
    {
        anim.Play("Stop");
        print(other.name);
        if(other.name.Contains("Stand"))
        {
             touching = other.gameObject;
             touching.SendMessage("toggleX");
        }
        touching = null;
    
    } 
}
