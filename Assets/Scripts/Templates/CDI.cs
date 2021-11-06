using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script needs to call the animator function from the IDI script
//bring the GameObject and script in
//call the animator function in the Activate() function

public class CDI : MonoBehaviour
{
    // public GameObject IDI_number;
    // IDIactualScriptName IDI_script;

    // Start is called before the first frame update
    void Start()
    {
        // IDI_script = IDI_number.GetComponent<IDIactualScriptName>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        // IDI_script.animatorFunction();
    }
}
