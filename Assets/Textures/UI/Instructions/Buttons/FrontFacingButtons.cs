using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontFacingButtons : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera m_Camera;

    private void Start()
    {
        m_Camera = Camera.main;
    } 

    void Update()
    {
        transform.rotation = m_Camera.transform.rotation;
    }

            
}
