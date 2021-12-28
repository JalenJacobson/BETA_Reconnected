using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteBotRaiseButton : MonoBehaviour
{
    public GameObject BruteBotRaisePoint;
    public BruteBotRaisePoint BotRaisePoint_Script;


    void Start()
    {
       BotRaisePoint_Script = BruteBotRaisePoint.GetComponent<BruteBotRaisePoint>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        BotRaisePoint_Script.Activate();
    }
}
