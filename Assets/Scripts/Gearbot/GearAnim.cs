using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearAnim : MonoBehaviour
{
   public Animator anim;
   // public AudioSource mySound;
    

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
        var audioClip = Resources.Load<AudioClip>("GearBotAudio");  //Load the AudioClip from the Resources Folder
       // mySound.clip = audioClip;
 }
 
 // Update is called once per frame
 void Update () {
        if (Input.GetKeyDown("z"))
        {
            Play();

        }
        if (Input.GetKeyDown("z"))
        {
       // mySound.Play();

        }
    }
public void Play()
{
  anim.Play("Gears");
}


}