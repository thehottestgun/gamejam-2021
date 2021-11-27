using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Interaction
{
    public Dialogue Dialogue;

    private GameObject _dialogueManager;
    // Start is called before the first frame update

    protected override void Interact()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
    }
}
