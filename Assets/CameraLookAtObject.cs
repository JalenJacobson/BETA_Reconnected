using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtObject : MonoBehaviour
{
    public GameObject botToFollow;
    public GameObject[] botsInitial;
    public List<GameObject> bots;
    public GameObject CameraLookAtSatControl;
    public GameObject Satbot;
    public SatMove SatMove_Script;
    public BotSelect followIndicator;

    public int selectedBot = 0;

    void Awake()
    {
        Satbot = GameObject.Find("SatBot");
        SatMove_Script = Satbot.GetComponent<SatMove>();
    }

    void Start()
    {
        CameraLookAtSatControl = GameObject.Find("CameraLookAtSatControl");
        botsInitial = GameObject.FindGameObjectsWithTag("Bot");
        bots.Add(CameraLookAtSatControl);
        botToFollow = CameraLookAtSatControl;
        foreach (GameObject botInitial in botsInitial)
        {
            bots.Add(botInitial);
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!SatMove_Script.controllingCamera)
        {
            followIndicator.anim.Play("Idle");
        }
        else if(SatMove_Script.controllingCamera == true)
        {
            followIndicator.anim.Play(botToFollow.name);  
        }
        if(botToFollow)
        {
            transform.position = botToFollow.transform.position;
        } 
    }

    public void followBotNext()
    {
        
        selectedBot = (selectedBot + 1) % bots.Count;
        botToFollow = bots[selectedBot];
        //followIndicator.anim.Play(botToFollow.name);
    }

    public void followBotPrevious()
    {
        
        selectedBot --;
        if(selectedBot < 0 )
        {
            selectedBot += bots.Count;
        }
        botToFollow = bots[selectedBot];
        //followIndicator.anim.Play(botToFollow.name);
    }

    
}
