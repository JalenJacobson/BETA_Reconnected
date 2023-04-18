using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Dialogue_Button : MonoBehaviour
{
    public Animator anim;
    public bool dialogueComplete;

    public Dialogue dialogue;
    
    
    // Start is called before the first frame update
    void Start()
    {
         anim = GetComponent<Animator>(); 
             
    }

    public void triggerDialogue()
    {
        FindObjectOfType<Tutorial_Dialogue>().startDialogue(dialogue);
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
