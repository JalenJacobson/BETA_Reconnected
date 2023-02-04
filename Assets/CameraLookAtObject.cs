using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtObject : MonoBehaviour
{
    public GameObject[] botsInitial;
    public List<GameObject> bots;

    public int selectedBot = 0;

    void Start()
    {
        botsInitial = GameObject.FindGameObjectsWithTag("Bot");
        foreach (GameObject botInitial in botsInitial)
        {
            bots.Add(botInitial);
        }
        // bots.Add(nullGameObjectFollow)
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!botToFollow) return;
        if(botToFollow)
        {
            transform.position = botToFollow.Transform.position;
        } 
    }

    public void followBotNext()
    {
        
        selectedBot = (selectedBot + 1) % bots.Count;
        botToFollow = bots[selectedBot]
    }

    public void followBotPrevious()
    {
        
        selectedBot --;
        if(selectedBot < 0 )
        {
            selectedBot += bots.Count;
        }
        botToFollow = bots[selectedBot]
    }

    
}
