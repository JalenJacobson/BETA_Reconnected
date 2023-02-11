using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTextHackerScene : MonoBehaviour
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
    }

    public void Startle()
    {
        StartCoroutine(introText());
        StartCoroutine(goToVideo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator introText()
    {
        yield return new WaitForSeconds(1);
        source.PlayOneShot(clip1);
        yield return new WaitForSeconds(6);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(5);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip2);
        yield return new WaitForSeconds(3);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(6);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(5);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip1);
        yield return new WaitForSeconds(6);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip2);
        yield return new WaitForSeconds(3);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(6);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip1);
        yield return new WaitForSeconds(7);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip1);
        yield return new WaitForSeconds(6);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip2);
        yield return new WaitForSeconds(3);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip2);
        yield return new WaitForSeconds(3);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(6);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(5);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip2);
        yield return new WaitForSeconds(5);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(5);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(5);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip1);
        yield return new WaitForSeconds(7);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip2);
        yield return new WaitForSeconds(5);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        source.PlayOneShot(clip2);
    }

    IEnumerator goToVideo()
    {
        yield return new WaitForSeconds(103);
        LevelManager_Script.loadStoryIntroVideoScene();
    }
}
