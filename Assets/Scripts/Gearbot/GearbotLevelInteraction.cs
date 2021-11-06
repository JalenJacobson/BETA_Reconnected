using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearbotLevelInteraction : MonoBehaviour
{

    public bool toggleSelected = true;
    public bool canInteract = false;
    public bool canInteract2 = false;
    
    public GameObject GearBoxTrigger;
    Gearbox1 GearBoxTrigger_script;

    public GameObject level_gears_gearbox_2;
    Gearbox_2 GearBoxTrigger_script2;

    // Start is called before the first frame update
    void Start()
    {
        GearBoxTrigger_script = GearBoxTrigger.GetComponent<Gearbox1>();
        GearBoxTrigger_script2 = level_gears_gearbox_2.GetComponent<Gearbox_2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(toggleSelected == true && canInteract == true)
        {
            if (Input.GetKeyDown("z"))
                {
                    // GearBoxTrigger_script.changeGearPos();
                }
        }
        else if(toggleSelected == true && canInteract2 == true)
        {
            if(Input.GetKeyDown("z"))
            {
                // GearBoxTrigger_script2.changeGearPos();
            }
            
        }
        
        
    }

    public void toggleSelectedState (){
        toggleSelected = !toggleSelected;
    }

    public void canInteractEnter(){
        canInteract = true;
    }
    public void canInteractExit(){
        canInteract = false;
    }
    public void canInteractEnter2(){
        canInteract2 = true;
    }
    public void canInteractExit2(){
        canInteract2 = false;
    }

}
