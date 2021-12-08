using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pump_Gasconnection : MonoBehaviour
{
    public Animator anim;
    // IDI's
    // public GameObject Fire;
    // Fire firestop_Script;
    // public GameObject Fire_1;
    // Fire firestop2_Script;
    // public GameObject Fire_2;
    // Fire firestop3_Script;

    public List<GameObject> fires;
    public List<Fire> fire_Scripts;
    public float TimeDeactivated = 5;



    // Start is called before the first frame update
    public void Start()
    {
         anim = GetComponent<Animator>();
        // firestop_Script = Fire.GetComponent<Fire>();
        // firestop2_Script = Fire_1.GetComponent<Fire>();
        // firestop3_Script = Fire_2.GetComponent<Fire>();
        getFireScripts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getFireScripts()
    {
        foreach(GameObject fire in fires)
        {
            var fire_Script = fire.GetComponent<Fire>();
            fire_Scripts.Add(fire_Script);
        }
    }

    public void Activate()
    {
        StartCoroutine(ValveBoxSequence());
    //    firestop_Script.deactivateFire(); 
    //    firestop2_Script.deactivateFire(); 
    //    firestop3_Script.deactivateFire(); 
        foreach(Fire fire_Script in fire_Scripts)
        {
            fire_Script.Activate();
        }
    }
      public IEnumerator ValveBoxSequence()
  {
    anim.Play("ActivateValveBox");
    yield return new WaitForSeconds(TimeDeactivated);
    anim.Play("DeactivateValveBox");
  }

    public void Deactivate()
    {
        // firestop_Script.Play();
        // firestop2_Script.Play();
        // firestop3_Script.Play();
    }
}
