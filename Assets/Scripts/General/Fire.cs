using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
  public Animator anim;
  

    void Start()
    {
          anim = GetComponent<Animator>();      
    }
    public void Play()
    {
      anim.Play("FireIdle");
    }
    public void Stop()
    {
      anim.Play("FireStop");
    }
}
