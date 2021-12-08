using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearConection_Raisers : CDI_Class
{
    public float TimeDeactivated = 5;
    public GameObject GearRaiser;
    Boxes GearRaiser_script;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        GearRaiser_script = GearRaiser.GetComponent<Boxes>();
        message = "Raiser Activated";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        StartCoroutine(GearBoxSequence());
        GearRaiser_script.Activate();
        // sndMessage.text = message;
    }
    public IEnumerator GearBoxSequence()
  {
    anim.Play("ActivateGearBox");
    yield return new WaitForSeconds(TimeDeactivated);
    anim.Play("DeactivateGearBox");
  }
}
