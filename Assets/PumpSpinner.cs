using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpSpinner : MonoBehaviour
{
   public Animator anim;
    public bool spun = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(spun == true)
        {
            anim.Play("SpinnerGreen");
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.name == "WindTrigger" && spun == false)
        {
          StartCoroutine(Spin());
        } 
    }
    void OnTriggerExit(Collider other)
    {
        if(spun == false)
        {
          StopAllCoroutines();
          anim.Play("SpinnerIdle");
        }
    }

    public IEnumerator Spin()
    {
    anim.Play("SpinnerRed");
    yield return new WaitForSeconds(3);
    spun = true;
    }
}
