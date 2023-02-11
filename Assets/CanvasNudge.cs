using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasNudge : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Nudge()
    {
        anim.Play("HackerRoomCanvasNudge");
    }
    public void NudgeCanvasOff()
    {
        anim.Play("HackerNudgeCanvasOff");
    }
    public void Computeroff()
    {
        anim.Play("HackerComputerStop");
    }
    public void FadeMusic()
    {
        anim.Play("IntroHackerFade");
    }
    public void InteractiveCamera()
    {
        anim.Play("InteractiveCameraInHackerRoom");
    }
}
