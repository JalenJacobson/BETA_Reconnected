using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueWall : MonoBehaviour
{
  public Animator anim;

  void Start () 
  {  
    anim = GetComponent<Animator>();
  }

  void OnTriggerEnter(Collider other)
  {
    var characterName = other.name;
    print(characterName);
    if(characterName == "Brute" || characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot")
    {
      other.gameObject.SendMessage("pumpAirBubbleEnter"); 
    }
            
  }
     
  void OnTriggerExit(Collider other)
  {
    var characterName = other.name;
    print(characterName);
    if(characterName == "Brute" || characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot")
    {
      other.gameObject.SendMessage("pumpAirBubbleExit"); 
    }     
  }
  
  public void Play()
  {
    anim.Play("BlueWallOpen");
  }
  public void Stop()
  {
    anim.Play("BlueWallClose");
  }
}
