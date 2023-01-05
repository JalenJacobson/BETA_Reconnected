using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerConnection_LightningGate : MonoBehaviour
{
    public GameObject LightningGate;
    public LightningGate LightningGate_script;
    public float TimeDeactivated = 3;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        LightningGate_script = LightningGate.GetComponent<LightningGate>();
        //message = "Lift Activated";
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        StartCoroutine(OutletSequence());
        LightningGate_script.Activate();
    }
          public IEnumerator OutletSequence()
  {
    anim.Play("ActivateOutlet");
    yield return new WaitForSeconds(TimeDeactivated);
    anim.Play("DeactivateOutlet");
  }
}