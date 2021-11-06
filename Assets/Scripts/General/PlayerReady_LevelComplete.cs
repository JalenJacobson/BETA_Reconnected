using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReady_LevelComplete : MonoBehaviour
{
    public GameObject StartPort;
    public LevelComplete levelcomplete_script;

    // Start is called before the first frame update
    void Start()
    {
        levelcomplete_script = StartPort.GetComponent<LevelComplete>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter(Collider other)
     {
        var characterName = other.name;
        if(characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump" || characterName == "Brute")
        {
            levelcomplete_script.SendMessage("addPlayerReady");
        }
     }
     void OnTriggerExit(Collider other)
     {
         var characterName = other.name;
        if(characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump" || characterName == "Brute")
        {
            levelcomplete_script.SendMessage("removePlayerReady");
        }
     }
}
