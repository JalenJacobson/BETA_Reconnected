using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenRoomLuz : MonoBehaviour
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

    void OnTriggerStay(Collider other)
    {
    var characterName = other.name;
    if(characterName == "IdleLuz")
    {
        anim.Play("LightRoom");
    }
    }

    void OnTriggerExit(Collider other)
    {
    var characterName = other.name;
    if(characterName == "IdleLuz")
    {
        anim.Play("DarkenRoom");
    }
    }
}
