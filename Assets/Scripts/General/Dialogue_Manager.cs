using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Manager : MonoBehaviour
{
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void startDialogue(Dialogue dialogue)
    {
        print("starting conversation with" + dialogue.name);
    }

    
}
