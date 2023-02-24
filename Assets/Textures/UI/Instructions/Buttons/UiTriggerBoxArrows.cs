using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTriggerBoxArrows : MonoBehaviour
{
    public Animator anim;
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
            if(other.name.Contains("TriggerCube") || other.name.Contains("Brute"))
            {
             anim.Play("BoxArrows");
            }
         }

    void OnTriggerExit(Collider other)
         {
            if(other.name.Contains("TriggerCube") || other.name.Contains("Brute"))
            {
             anim.Play("BoxArrowsDown");
            }
         }
}
