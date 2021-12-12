using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoLayer : MonoBehaviour
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
    public void Pump()
   {
       anim.Play("P1Info");

   }
    public void Brute()
   {
       anim.Play("P1Info");

   }
    public void Gears()
   {
       anim.Play("P1Info");

   }
     public void Sat()
   {
       anim.Play("P1Info");

   }
     public void Luz()
   {
       anim.Play("P1Info");

   }
       public void PumpDown()
   {
       anim.Play("P1InfoDown");

   }
    public void BruteDown()
   {
       anim.Play("P1InfoDown");

   }
    public void GearsDown()
   {
       anim.Play("P1InfoDown");

   }
     public void SatDown()
   {
       anim.Play("P1InfoDown");

   }
     public void LuzDown()
   {
       anim.Play("P1InfoDown");

   }
        public void P2Up()
   {
       anim.Play("P2Info");

   }
           public void P2Down()
   {
       anim.Play("P2InfoDown");

   }
    public void P1Cancel()
   {
       anim.Play("InfoCancel");

   }
       public void P2Cancel()
   {
       anim.Play("P2InfoCancel");

   }
}