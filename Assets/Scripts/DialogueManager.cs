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

    private Animator _dialogueBoxAnimator, _faderAnimator;

    private bool finalDialouge;
    // Start is called before the first frame update
    void Start()
    {
        _sentences = new Queue<string>();
        _inDialogue = false;
        _dialogueBoxAnimator = GameObject.Find("Dialogue Box").GetComponent<Animator>();
        _dialogueBox = GameObject.Find("Dialogue Box").transform.GetComponentInChildren<TextMeshProUGUI>();
        _faderAnimator = GameObject.Find("Fader").GetComponent<Animator>();
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
        _dialogueBoxAnimator.SetBool("InDialogue",true);
        Debug.Log("Starting conversation with " + dialogue.name);
        finalDialouge = dialogue.name == "final";
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
            EndDialogue(name);
            return;
        }

        var sentence = _sentences.Dequeue();
        _dialogueBox.text = sentence;
        Debug.Log(sentence);
    }

    void EndDialogue(string name)
    {
        _dialogueBoxAnimator.SetBool("InDialogue",false);
        _dialogueBox.text = "";
        if (finalDialouge)
        {
            FaderSceneProgress.progressToNextScene = true;
            _faderAnimator.SetBool("Fading",true);
        }
        
        Debug.Log("End of conversation.");
    }
}
