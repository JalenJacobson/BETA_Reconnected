using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    public Animator anim;
    public List<GameObject> Targets;
    public GameObject TutorialCanvas;
    public string objectThatShouldTrigger;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains(objectThatShouldTrigger))
        {
            DisplayOff();
        }
    }

    public void DisplayOff()
    {
        foreach(GameObject Target in Targets)
        {
            Target.SendMessage("Display");
            anim.Play("TutorialDisplayOff");
            TutorialCanvas.SendMessage("tutorialTextOn");
        }
    }

    public void Display()
    {
        anim.Play("TutorialDisplay");
    }
}
