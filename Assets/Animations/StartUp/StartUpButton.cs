using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpButton : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
         anim = GetComponent<Animator>();       
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
