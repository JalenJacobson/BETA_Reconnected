using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_Crawler_Mover_Zaxis : MonoBehaviour
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
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w"))
             {
                 anim.Play("Forward");
             }

            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp("w"))
             {
                 anim.Play("Stop");
             }

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("s"))
             {
                 anim.Play("Backward");
             }

            if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp("s"))
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
             touching.SendMessage("toggleZ");
        }
    
    } 
    void OnTriggerExit(Collider other)
    {
        touching = null;
        //   anim.Play("Stop");
        print(other.name);
        if(other.name.Contains("Stand"))
        {
             touching = other.gameObject;
             touching.SendMessage("toggleZ");
        }
        touching = null;
    
    } 
}
