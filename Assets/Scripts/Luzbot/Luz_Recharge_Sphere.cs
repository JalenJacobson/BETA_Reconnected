using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz_Recharge_Sphere : MonoBehaviour
{
    public GameObject touching;

    public List<GameObject> touchingBots;

    void OnTriggerEnter(Collider other)
    {
        var characterName = other.name;
        if(characterName == "Brute" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump" || characterName.Contains("LightBulb"))
        {
            // if(touching == null)
            // {
            //     touching = other.gameObject; 
            // }

            // touching.SendMessage("restoreHealth");
            touchingBots.Add(other.gameObject);
            StartCoroutine(Remove());
        }
        
    }


    IEnumerator Remove()
    {
        yield return new WaitForSeconds(2f);
        touchingBots.Clear();
    }

    public void Update()
    {
        if(touchingBots.Count > 0)
        {
            foreach (var bot in touchingBots)
            {
                bot.SendMessage("HealBattery");
                bot.SendMessage("restoreHealth");
                //touchingBots.Remove(bot);
            }
        }
    }
}
