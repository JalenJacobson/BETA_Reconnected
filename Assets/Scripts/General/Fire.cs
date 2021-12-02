using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
  public Animator anim;
  public bool fireActive = true;
  

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

  public void OnTriggerEnter(Collider other)
  {
    if(!fireActive) return;
    if(other.name.Contains("Gear") || other.name.Contains("Brute") || other.name.Contains("Luz") || other.name.Contains("Pump") || other.name.Contains("Sat"))
    {
      other.gameObject.SendMessage("death");
    }
  }  

  public void Activate()
  {
    StartCoroutine(fireActivateDeactivateSequence());
  }

  public void deactivateFire()
  {
    anim.Play("FireStop");
    fireActive = false;
  }

  public void activateFire()
  {
    anim.Play("FireIdle");
    fireActive = true;
  }

  public IEnumerator fireActivateDeactivateSequence()
  {
    deactivateFire();
    yield return new WaitForSeconds(2);
    activateFire();
  }
}
