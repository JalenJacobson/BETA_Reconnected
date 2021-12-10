using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoStart : MonoBehaviour
{
    
    public VideoPlayer videoPlayer; 
    
    // Start is called before the first frame update
    void Start()
    {
    videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,"IntroSplashScrene.mp4");
    videoPlayer.Play();
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
