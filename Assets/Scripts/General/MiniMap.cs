using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public GameObject rawImage;
    public bool isActive;
    
    void Start()
    {
        isActive = false;  
        rawImage.SetActive(isActive); 
    }

    // Update is called once per frame
    void Update()
    {
        // renderActive();
        if (Input.GetKeyDown("m"))
        {
            toggleActive();
        }
    }

    public void toggleActive()
    {
        isActive = !isActive;
        rawImage.SetActive(isActive);
    }

    // public void renderActive()
    // {
    //     if(isActive)
    //     {
    //         rawImage.SetActive(true);
    //     }
    //     else{rawImage.SetActive(false);}
    // }
}
