using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectPortal : MonoBehaviour
{
    public bool LevelActive = false;
    public Animator anim;
    public TwoPlayerCameraFollow CameraFollow_Script;
    public bool sentCameraConnecteMessage = false;
    public bool sentCameraDisconnecteMessage = false;
    public GameObject lookPoint;
    public Vector3 lookPos;
    public Vector3 desiredAngle;
    public Vector3 oldAngle;
    // Start is called before the first frame update
    void Start()
    {
    anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    void FixedUpdate()
    {
        if(LevelActive)
        {
         anim.Play("PortalActive");   
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {
     callCameraFollow();
    }
    public void callCameraFollow()
    {
        sentCameraConnecteMessage = true;
        sentCameraDisconnecteMessage = false;
        CameraFollow_Script.followObject(lookPoint, "Screen");
        CameraFollow_Script.desiredAngle = desiredAngle;
    }

    public void OnTriggerExit(Collider other)
    {
     callCameraUnfollow();
    }
    public void callCameraUnfollow()
    {
        sentCameraDisconnecteMessage = true;
        sentCameraConnecteMessage = false;
        CameraFollow_Script.unfollowObject();
        CameraFollow_Script.desiredAngle = oldAngle;
    }
}
