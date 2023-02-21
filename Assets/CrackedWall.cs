using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedWall : MonoBehaviour
{
    public Animator anim;
    public bool broken = false;
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
        if(other.name == "Mech_Drill" && broken == false)
        {
          StartCoroutine(BreakWall());
        } 
    }
    void OnTriggerExit(Collider other)
    {
        if(broken == false)
        {
          StopAllCoroutines();
          anim.Play("WallIdle");
        }
    }

    public IEnumerator BreakWall()
    {
    anim.Play("BreakingWall");
    yield return new WaitForSeconds(2);
    anim.Play("BreakWall");
    broken = true;
    }
  
}
