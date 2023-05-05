using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tutorial_Dialogue : MonoBehaviour
{
    public Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public AudioSource source;
    public AudioClip clip;
    public GameObject CloseTutorialButton;
    public GameObject NextDialogue_Button;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        //source.PlayOneShot(clip);  
    }

    public void startDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //source.PlayOneShot(clip);  
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = sentence;
        // foreach (char letter in sentence.ToCharArray())
        // {
        //     dialogueText.text += letter;
        // }
        yield return null;
    }

    void EndDialogue()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(CloseTutorialButton);
        print("end of conversation");
    }

    public void NextDialogueButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(NextDialogue_Button);
    }

    
}
