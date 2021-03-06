using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanInteract_Gear : MonoBehaviour
{
    public bool displayMessage = false;
    public string message = "press z to use";


    void OnTriggerEnter(Collider other)
     {
         print(other.name);
         if(other.name == "Gears"){
            displayMessage = true;
            other.gameObject.SendMessage("canInteractEnter"); 
         } 
         else{
             print("not gears");
         }
            
     }
     void OnTriggerExit(Collider other)
     {
        print(other.name);
        if(other.name == "Gears"){
            displayMessage = false;
            other.gameObject.SendMessage("canInteractExit");
        }        
        else{
            print("not gears!");
        }
     }

     void OnGUI () {
     if (displayMessage) {
         print("worked");
         GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), message);
        }
    }
}
