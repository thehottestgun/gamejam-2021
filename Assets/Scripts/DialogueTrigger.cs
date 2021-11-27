using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Interaction
{
    public Dialogue Dialogue;

    private GameObject _dialogueManager;
    // Start is called before the first frame update

    private void Update()
    {
        Interact();
    }

    protected override void Interact()
    {
        if (!_inRange || !Input.GetButton("Interaction")) return;
        Debug.Log("Oh boy");
        FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);

    }
}
