using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    public bool isBeingCarried;
    public Vector3 liftPos;
    public GameObject Brute;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Brute = GameObject.Find("Brute");
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleIsBeingCarried()
    {
        if(!isBeingCarried)
        {
            
            GetComponent<Rigidbody>().useGravity = false;
            isBeingCarried = !isBeingCarried; 
            transform.position = Brute.transform.TransformPoint(liftPos);
            gameObject.AddComponent<FixedJoint>();
            gameObject.GetComponent<FixedJoint>().connectedBody=Brute.GetComponent<Rigidbody>();
            anim.Play("Drill");
            
        }
        else if(isBeingCarried)
        {
                isBeingCarried = !isBeingCarried; 
                Destroy(gameObject.GetComponent<FixedJoint>());
                GetComponent<Rigidbody>().useGravity = true; 
                anim.Play("DrillIdle"); 
        }
    }
}
