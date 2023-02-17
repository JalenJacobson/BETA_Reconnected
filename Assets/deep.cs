using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deep : MonoBehaviour
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

    public void Deep()
    {
        anim.Play("ContinueDeep");
    }
     public void Continue()
    {
        anim.Play("Continue");
    }

  
}
