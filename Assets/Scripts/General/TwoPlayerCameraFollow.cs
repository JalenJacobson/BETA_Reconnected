using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerCameraFollow : MonoBehaviour
{
    public Camera cam;
    public GameObject[] bots;
    public Transform bot1;
    public Transform bot2;

    public float zoomInMax = 35f;
    public float zoomOutMax = 45f;

    void Start()
    {
        bots = GameObject.FindGameObjectsWithTag("Bot");
        bot1 = bots[0].GetComponent<Transform>();
        bot2 = bots[1].GetComponent<Transform>();
    }

    void Update()
    {
        FixedCameraFollowSmooth(cam, bot1, bot2);
    }

    public void FixedCameraFollowSmooth(Camera cam, Transform t1, Transform t2)
    {
        float zoomFactor = 1.2f;
        float followTimeDelta = 0.1f;

        Vector3 midpoint = (t1.position + t2.position) / 2f;
 
        float distance = (t1.position - t2.position).magnitude;
 
     
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
}
