using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushreturn : MonoBehaviour
{
    public Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void death()
    {
    StartCoroutine(ReturnBox());
        
    }
    public IEnumerator ReturnBox()
    {
        yield return new WaitForSeconds(1);
        transform.position = startPos;
    }
}
