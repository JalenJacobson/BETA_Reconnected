using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
  public bool holeActive = true;
  public float TimeDeactivated = 5;
  

  void Start()
  {
  
  }


  public void OnTriggerEnter(Collider other)
  {
    // if(!fireActive) return;
    if(holeActive)
    {
      if(other.name.Contains("Gear") || other.name.Contains("Brute") || other.name.Contains("Luz") || other.name.Contains("Pump") || other.name.Contains("Sat"))
      {
        other.gameObject.SendMessage("death");
      }
    }
    
  }  

  public void Activate()
  {
    StartCoroutine(fireActivateDeactivateSequence());
  }

  public void deactivateHole()
  {
    holeActive = false;
  }

  public void activateHole()
  {
    holeActive = true;
  }

  public IEnumerator fireActivateDeactivateSequence()
  {
    deactivateHole();
    yield return new WaitForSeconds(TimeDeactivated);
    activateHole();
  }
}
