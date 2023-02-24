using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushreturn : MonoBehaviour
{
    public Vector3 startPos;
    public bool fallen = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        StartCoroutine(ReturnLiveBox());
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fallen)
        {
            StartCoroutine(ReturnBox());
        }
    }

   public void death()
    {
        if(!fallen)
        {
            StopAllCoroutines();
        }
        fallen = true;
        
    }
    public IEnumerator ReturnBox()
    {
        if(fallen)
        {
            yield return new WaitForSeconds(1);
            transform.position = startPos;
            yield return new WaitForSeconds(.1f);
            fallen = false;
            StartCoroutine(ReturnLiveBox());
        }
    }
    public IEnumerator ReturnLiveBox()
    {
        yield return new WaitForSeconds(40);
        transform.position = startPos;
        StartCoroutine(ReturnLiveBox());
    }
}
