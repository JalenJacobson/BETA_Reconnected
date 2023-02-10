using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTextHackerScene : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject LevelManager;
    public Level_Manager LevelManager_Script;
    // Start is called before the first frame update
    void Start()
    {
        LevelManager_Script = LevelManager.GetComponent<Level_Manager>();
        FindObjectOfType<Dialogue_Manager>().startDialogue(dialogue);
        StartCoroutine(introText());
        StartCoroutine(goToVideo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator introText()
    {
        yield return new WaitForSeconds(2);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(4);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(4);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(2);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(2);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(4);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(4);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(2);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(2);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(4);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(4);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(2);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(2);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(4);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(4);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(2);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(2);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(4);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
        yield return new WaitForSeconds(4);
        FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
    }

    IEnumerator goToVideo()
    {
        yield return new WaitForSeconds(100);
        LevelManager_Script.loadStoryIntroVideoScene();
    }
}
