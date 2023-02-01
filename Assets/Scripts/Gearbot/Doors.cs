using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Animator anim;
    public int toOpen = 2;
    public int activated = 0;

    public GameObject[] Doors_Boxes;
    public List<GameObject> GateIndicators;
    public List<GameObject> TokenIndicators;
    public GameObject[] Tokens;

    public int tokensCollected = 0;



 // Use this for initialization
    void Start () 
    {
        anim = GetComponent<Animator>();
        
        Doors_Boxes = GameObject.FindGameObjectsWithTag("Doors_Boxes");
        toOpen = Doors_Boxes.Length;
        for (var i = 0; i < toOpen; i++)
        {
            GateIndicators[i].GetComponent<Animator>().Play("IndicatorLocked");
        }
        Tokens = GameObject.FindGameObjectsWithTag("Token");
    }
 
 // Update is called once per frame
    public virtual void Update () 
    {
        if (activated >= toOpen)
        // if (GatePowerConnection1_script.active == true  && GateGearObj_script.active == true)
        {
            anim.Play("Doors");
        }
    }

    public void Activate()
    {
        GateIndicators[activated].GetComponent<Animator>().Play("IndicatorUnlocked");
        activated++;
    }
    public void CollectToken()
    {
        TokenIndicators[tokensCollected].GetComponent<Animator>().Play("TokenCollectedUI");
        tokensCollected++;
    }

    
}
