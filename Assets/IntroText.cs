using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroText : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject LevelManager;
    public Level_Manager LevelManager_Script;
    public AudioSource source;
    public AudioClip clip;
    public AudioClip clip1;
    public AudioClip clip2;
    // Start is called before the first frame update
    void Start()
    {
        LevelManager_Script = LevelManager.GetComponent<Level_Manager>();
        FindObjectOfType<Dialogue_Manager>().startDialogue(dialogue);
        StartCoroutine(introText());
        StartCoroutine(goToHackerRoom());
        source.PlayOneShot(clip1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator introText()
    {
        yield return new WaitForSeconds(7);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip2);
        yield return new WaitForSeconds(2);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(4);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip2);
        yield return new WaitForSeconds(5);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip2);
        yield return new WaitForSeconds(6);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(7);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip1);
        source.PlayOneShot(clip2);
        yield return new WaitForSeconds(7);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip1);
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(11);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip2);
        yield return new WaitForSeconds(9);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip2);
    }

    IEnumerator goToHackerRoom()
    {
        yield return new WaitForSeconds(55);
        LevelManager_Script.loadStoryHackerScene();
    }
}
