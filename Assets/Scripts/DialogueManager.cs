using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> _sentences;

    private bool _inDialogue;

    private TextMeshProUGUI _dialogueBox;
    // Start is called before the first frame update
    void Start()
    {
        _sentences = new Queue<string>();
        _inDialogue = false;
        _dialogueBox = GameObject.Find("Dialogue Box").transform.GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(_dialogueBox.text);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Confirm") && _inDialogue)
        {
            Debug.Log(_sentences.Count);
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);

        _inDialogue = true;
        
        _sentences.Clear();

        foreach (var sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            _inDialogue = false;
            EndDialogue();
            return;
        }

        var sentence = _sentences.Dequeue();
        _dialogueBox.text = sentence;
        Debug.Log(sentence);
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation.");
    }
}
