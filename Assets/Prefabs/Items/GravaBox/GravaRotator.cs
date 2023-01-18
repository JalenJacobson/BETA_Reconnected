using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravaRotator : MonoBehaviour
{
    public bool RotatorConnected = false;
    public float rotateSpeed = 2;
    public string moveAxisHorizontal;
    public Vector3 direction;
    public GameObject GravaBox;
    public Animator anim;
    

    void Awake()
    {
       
    }

    void Start()
    {
        anim = GravaBox.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void Movement(float x, float y)
    {
        
        if (x != 0)
        {
            transform.Rotate(0, x * rotateSpeed, 0, Space.World);   
        }
        if (y != 0)
        {
            transform.Rotate(y * rotateSpeed, 0, 0, Space.World);   
        }
    }

    public void ActivateAnim()
    {
        anim.Play("ActivateGravaBox");
    }
    public void DeactivateAnim()
    {
        anim.Play("DeactivateGravaBox");
    }
}
