using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePortals : CDI_Class
{

    public GameObject PortalA;
    public Portal portala_script;
    public GameObject PortalB;
    public Portal portalb_script;
    // public Animator anim;
    public bool Active = false;
    // Start is called before the first frame update
    void Start()
    {
        portala_script = PortalA.GetComponent<Portal>();
        portalb_script = PortalB.GetComponent<Portal>();
        //quickLookObject = PortalA;
        //quickLookObjectOffset = new Vector3(0.0f, 15f, -2f);
        //quickLookWhenActivated = true;
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
       if(Active == true)
        anim.Play("PortalBoxActive"); 
    }


    void Activate()
    {
        StartCoroutine(activateItemSequence());
    }

    public override void activateItem()
    {
        portala_script.makeActive();
        portalb_script.makeActive();
        Active = true;
    }
}
