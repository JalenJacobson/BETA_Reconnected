using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialCanvas : MonoBehaviour
{
    public GameObject TutorialButton;
    public GameObject TutorialDialogueButton;
    public GameObject FirstTarget;
    public Animator anim;
    public bool gameIsPaused = false;
    public AudioSource Music;
    public GameObject Tutorial_Dialogue;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        FirstTarget.SendMessage("Display"); 
        StartCoroutine(TutorialText());
        Music = GameObject.Find("Music").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void textOff()
    {
        anim.Play("TutorialInfoOff");
        Time.timeScale = 1f;
        gameIsPaused = false;
        Music.volume = 1;
    }

    public void textOn()
    {
        anim.Play("TutorialInfo");
        Time.timeScale = 0f;
        gameIsPaused = true;
        Music.volume = .24f;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(TutorialDialogueButton);
    }

    public void tutorialTextOn()
    {
        anim.Play("TutorialInfo");
        Time.timeScale = 0f;
        gameIsPaused = true;
        Music.volume = .24f;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(TutorialButton);
    }

    public IEnumerator TutorialText()
    {
        yield return new WaitForSeconds(2.3f);
        textOn();
        //Tutorial_Dialogue.SendMessage("startDialogue");
    }

}
