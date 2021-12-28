using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerCameraFollow : MonoBehaviour
{
    public Camera cam;
    public GameObject camera;
    public GameObject[] bots;
    public Transform bot1;
    public Transform bot2;

    public float zoomInMax = 35f;
    public float zoomOutMax = 45f;
    public float damping = 1;
    Vector3 offset;
    public Vector3 stationaryCameraPosition;
    public bool stationaryCamera;
    public bool clawCarrying = false;
    public Vector3 desiredAngle;


    void Start()
    {
        bots = GameObject.FindGameObjectsWithTag("Bot");
        getObjectsToFollow(bots);
        print(camera.transform.eulerAngles.y);
        desiredAngle = camera.transform.eulerAngles;
    }

    void getObjectsToFollow(GameObject[] objectsToFollow)
    {
        bot1 = objectsToFollow[0].GetComponent<Transform>();
        bot2 = objectsToFollow[1].GetComponent<Transform>();
    }

    void LateUpdate()
    {
        

        // else FixedCameraFollowSmooth(cam, bot1, bot2);
    }

    void FixedUpdate()
    {
        if(stationaryCamera) return;
        if(!stationaryCamera && clawCarrying)
        {
            thirdPersonFollow("Gears");
        }
        else FixedCameraFollowSmooth(cam, bot1, bot2);
    }

    void Update()
    {
        
    }

    // public void stationaryCamera()
    // {

    // }

    public void thirdPersonFollow(string objectToIgnore)
    {
        var target = getThirdPersonTarget(objectToIgnore);
        offset = new Vector3(0, 20f, -15f);
        float followTimeDelta = 0.1f;
        Vector3 cameraDestination = target.transform.position + offset;
        
        
        // camera.transform.position = target.transform.position + offset;
        camera.transform.position = Vector3.Slerp(camera.transform.position, cameraDestination, followTimeDelta);
         
        camera.transform.LookAt(target.transform);

        if ((cameraDestination - camera.transform.position).magnitude <= 0.05f)
        {
            camera.transform.position = cameraDestination;
        }
    }

    public void FixedCameraFollowSmooth(Camera cam, Transform t1, Transform t2)
    {
        float zoomFactor = 1.2f;
        float followTimeDelta = 0.1f;

        Vector3 midpoint = (t1.position + t2.position) / 2f;
 
        float distance = (t1.position - t2.position).magnitude;

        camera.transform.eulerAngles = desiredAngle;
        Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;
    
        if(cameraDestination.y < zoomInMax)
        {
            cameraDestination.y = zoomInMax;
        }
        else if(cameraDestination.y > zoomOutMax)
        {  
            cameraDestination.y = zoomOutMax;
        }
 
        if (cam.orthographic)
        {
            cam.orthographicSize = distance;
        }
     
        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);

        if ((cameraDestination - cam.transform.position).magnitude <= 0.05f)
        {
            cam.transform.position = cameraDestination;
        }
    }

    public void followObject(GameObject pointToFollow, string botToReplace)
    {
        var newObjectsToFollow = new GameObject[2];
        newObjectsToFollow[0] = pointToFollow;
        foreach(GameObject bot in bots)
        {
            if(bot.gameObject.name != botToReplace)
            {
                newObjectsToFollow[1] = bot;
            }
        }
        getObjectsToFollow(newObjectsToFollow);
    }

    public void unfollowObject()
    {
        getObjectsToFollow(bots);
    }

    public GameObject getThirdPersonTarget(string objectToIgnore)
    {
        var liftedBot = new GameObject();
        foreach(GameObject bot in bots)
        {
            if(bot.gameObject.name != objectToIgnore)
            {
                liftedBot = bot;
            }
        }
        return liftedBot;
    }
}
