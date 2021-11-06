using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteTriggerCube : MonoBehaviour
{
    public Animator anim;
    public bool triggerEntered = false;
    public GameObject touching = null;
    public bool canLift = false;
    public Vector3 liftPos;
    public bool lifting;

    public GameObject ActionBrute;
    BruteBubbleScript Bubble_Script;
    public GameObject ActionLight;
    BruteBubbleScript Light_Script;
    public GameObject ActionCircles;
    BruteBubbleScript Circle_Script;
    
    public GameObject Cancel;
    CancelButton CancelButton_Script;
    public GameObject Brute;
    MoveBruteW AnimArms_Script;

    // public GameObject TimerBarBrute;
    // TimeBarBrute TimerBarBrute_Script;

    void Start()
    {
        liftPos = new Vector3(0.0f, -0.5f, -1.0f);
        anim = GetComponent<Animator>();
        Bubble_Script = ActionBrute.GetComponent<BruteBubbleScript>();
        Light_Script = ActionLight.GetComponent<BruteBubbleScript>();
        Circle_Script = ActionCircles.GetComponent<BruteBubbleScript>();
        CancelButton_Script = Cancel.GetComponent<CancelButton>();
        AnimArms_Script = Brute.GetComponent<MoveBruteW>();
        // TimerBarBrute_Script = TimerBarBrute.GetComponent<TimeBarBrute>();
    }

    void OnTriggerEnter(Collider other)
     {
          canLift = true;
     }

    void OnTriggerStay(Collider other)
    {
        var characterName = other.name;
        if(characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump")
        {
            if(touching == null)
            {
                touching = other.gameObject; 
            }
            Bubble_Script.actionBubbleStart();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart();   
        }
        
    }

     void OnTriggerExit(Collider other)
     { 
        var characterName = other.name;    
        if(characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump" || characterName.Contains("Box"))
        {   
            if(lifting == false)
            {
                canLift = false;
                touching = null;
            }
        Bubble_Script.actionBubbleStop();
        Light_Script.actionBubbleStop();
        Circle_Script.actionBubbleStop();
        // lifting = false;
        }
     }

     void Update()
     {   
        if(lifting == true)
        {
            touching.transform.position = transform.TransformPoint(liftPos);
            CancelButton_Script.CancelStart();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart();
            Bubble_Script.actionBubbleStop();
            AnimArms_Script.Lift(); 
        }
        
        
     }

     public void drop()
     {
        Light_Script.actionBubbleStop();
        Circle_Script.actionBubbleStop();
        CancelButton_Script.CancelStop();
        lifting = !lifting;
        touching.SendMessage("toggleIsBeingCarried");
        AnimArms_Script.Drop();  
     }
    
    public void lift() 
    {
        if(touching.name == "IdleLuz" || touching.name == "Gears" || touching.name == "SatBot" || touching.name == "Pump")
        {
            lifting = !lifting;
            touching.SendMessage("toggleIsBeingCarried");
        }
    }

}


 