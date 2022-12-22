using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pump_Gasconnection : CDI_Class
{
    // public Animator anim;
    public List<GameObject> fires;
    public List<Fire> fire_Scripts;
    public float TimeDeactivated = 5;

    

    public void Start()
    {
        anim = GetComponent<Animator>();
        //with multiple fires it may be best to set quickLookObject and quickLookOffset manually in the inspector to ensure view is correct
        //quickLookObject = fires[0];
        // quickLookObjectOffset = new Vector3(0.0f, .3f, -.2f);
        //quickLookWhenActivated = true;
        getFireScripts();
    }

    public void getFireScripts()
    {
        foreach(GameObject fire in fires)
        {
            var fire_Script = fire.GetComponent<Fire>();
            fire_Scripts.Add(fire_Script);
        }
    }

    // public void Activate()
    // {
    //     StartCoroutine(ValveBoxSequence());
    //     foreach(Fire fire_Script in fire_Scripts)
    //     {
    //         fire_Script.Activate();
    //     }
    // }
    
    public IEnumerator ValveBoxSequence()
    {
        anim.Play("ActivateValveBox");
        yield return new WaitForSeconds(TimeDeactivated);
        anim.Play("DeactivateValveBox");
    }

    void Activate()
    {
        StartCoroutine(activateItemSequence());
    }

    public override void activateItem()
    {
        StartCoroutine(ValveBoxSequence());
        foreach(Fire fire_Script in fire_Scripts)
        {
            fire_Script.Activate();
        }
    }
    
}
