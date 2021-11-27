using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : Interaction
{
    public Dialogue Dialogue;

    private GameObject _dialogueManager, _dialogueBox;

    [SerializeField] private AudioClip[] clip;
    // Start is called before the first frame update

    private void Start()
    {
        _dialogueBox = GameObject.Find("Dialogue Box");
    }

    private void Update()
    {
        Interact();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CompareTag("Money") && other.CompareTag("Player") && PlayerStats.cans == 1)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
            if(!(clip.Length>0)) return;
            AudioSource.PlayClipAtPoint(clip[0],transform.position,1);
        }

        if (CompareTag("Health") && SceneManager.GetActiveScene().buildIndex == 2)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
            if(!(clip.Length>0)) return;
            AudioSource.PlayClipAtPoint(clip[0],transform.position,1);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") && _dialogueBox.GetComponent<SpriteRenderer>().color.a >0)
        {
            _dialogueBox.GetComponent<Animator>().SetBool("InDialogue",false);
            _dialogueBox.GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
        _inRange = false;
    }
    
    protected override void Interact()
    {
        if (!_inRange || !Input.GetButtonDown("Interaction")) return;
        Debug.Log("Oh boy");
        FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
        
    }
}
