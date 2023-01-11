using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBlack : MonoBehaviour
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
    public void FadeBlackStart()
    {
        anim.Play("FadeBlack");
    }

    public void Fade()
    {
        anim.Play("Fade");
    }

    public void FadeMenuStart()
    {
        anim.Play("FadeMenuStart");
    }
    public void FadeMenuEnd()
    {
        anim.Play("FadeMenuEnd");
    }
}
