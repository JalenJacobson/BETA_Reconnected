using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUpButton : MonoBehaviour
{
    public Animator anim;
    public Button startButton;
    // Start is called before the first frame update
    void Start()
    {
         anim = GetComponent<Animator>();
         startButton = GetComponent<Button>(); 
         startButton.interactable = false;      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Initiate()
   {
       anim.Play("StartButtonDown");

   }
       public void newButtons()
   {
       anim.Play("NewButtons");

   }
          public void newButtonsDown()
   {
       anim.Play("StartButtonDown");

   }
}
