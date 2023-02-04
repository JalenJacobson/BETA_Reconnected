using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    public Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public GameObject Canvas;
    public Menu_navigator Canvas_Sript;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        Canvas_Sript = Canvas.GetComponent<Menu_navigator>();
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
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Canvas_Sript.BotSelect();
        print("end of conversation");
    }

    
}
