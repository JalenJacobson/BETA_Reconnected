using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteBotRaiseButton : MonoBehaviour
{
    public GameObject BruteBotRaisePoint;
    public BruteBotRaisePoint BotRaisePoint_Script;
    public Animator anim;


    void Start()
    {
       BotRaisePoint_Script = BruteBotRaisePoint.GetComponent<BruteBotRaisePoint>(); 
       anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        anim.Play("SpringPound");
        BotRaisePoint_Script.Activate();
    }
}
