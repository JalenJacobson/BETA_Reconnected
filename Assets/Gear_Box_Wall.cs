using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_Box_Wall : MonoBehaviour
{
    public string XorZ;
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
    public void Activate()
    {
        anim.Play("ActivateGearBox");
        StartCoroutine(Deactivate());
    }

    public IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(3);
        anim.Play("GearsSpin");
    }
}
