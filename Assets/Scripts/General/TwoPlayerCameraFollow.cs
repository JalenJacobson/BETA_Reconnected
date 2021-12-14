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
        // cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        bots = GameObject.FindGameObjectsWithTag("Bot");
        bot1 = bots[0].GetComponent<Transform>();
        bot2 = bots[1].GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        FixedCameraFollowSmooth(cam, bot1, bot2);
    }

    public void FixedCameraFollowSmooth(Camera cam, Transform t1, Transform t2)
 {
     // How many units should we keep from the players
     float zoomFactor = 1.2f;
     float followTimeDelta = 0.1f;
 
     // Midpoint we're after
     Vector3 midpoint = (t1.position + t2.position) / 2f;
 
     // Distance between objects
     float distance = (t1.position - t2.position).magnitude;
 
     // Move camera a certain distance
     Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;
    //  Vector3 cameraDestination = midpoint - cam.transform.forward * distance;
     if(cameraDestination.y < zoomInMax)
     {
         cameraDestination.y = zoomInMax;
     }
     else if(cameraDestination.y > zoomOutMax)
     {
         cameraDestination.y = zoomOutMax;
     }
 
     // Adjust ortho size if we're using one of those
     if (cam.orthographic)
     {
         // The camera's forward vector is irrelevant, only this size will matter
         cam.orthographicSize = distance;
     }
     // You specified to use MoveTowards instead of Slerp
     
     cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);
         
     // Snap when close enough to prevent annoying slerp behavior
     if ((cameraDestination - cam.transform.position).magnitude <= 0.05f)
         cam.transform.position = cameraDestination;
 }
}
