using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Interaction
{
    public Dialogue Dialogue;

    private GameObject _dialogueManager;

    [SerializeField] private AudioClip clip;
    // Start is called before the first frame update

    private void Update()
    {
        Interact();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Picked up");
        if (other.CompareTag("Player") && PlayerStats.cans == 1)
        {
            Debug.Log("Conds");
            FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
            AudioSource.PlayClipAtPoint(clip,transform.position,1);
        }
    }

    protected override void Interact()
    {
        if (!_inRange || !Input.GetButtonDown("Interaction")) return;
        Debug.Log("Oh boy");
        FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
        
    }
}
