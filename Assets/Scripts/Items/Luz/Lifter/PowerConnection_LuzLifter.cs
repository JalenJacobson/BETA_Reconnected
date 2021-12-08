using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerConnection_LuzLifter : CDI_Class
{
    public GameObject LuzLifter;
    public Lifter LuzLifter_script;
    public float TimeDeactivated = 3;
    // Start is called before the first frame update
    void Start()
    {
        LuzLifter_script = LuzLifter.GetComponent<Lifter>();
        message = "Lift Activated";
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        StartCoroutine(OutletSequence());
        LuzLifter_script.Activate();
    }
          public IEnumerator OutletSequence()
  {
    anim.Play("ActivateOutlet");
    yield return new WaitForSeconds(TimeDeactivated);
    anim.Play("DeactivateOutlet");
  }
}
