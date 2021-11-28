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
        if (CompareTag("Money") && other.CompareTag("Player") && PlayerStats.cans == 1 && SceneManager.GetActiveScene().buildIndex == 2)
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
        if (CompareTag("Shady") && SceneManager.GetActiveScene().buildIndex == 4)
        {
            Shady_Metro();
            return;
        }

        if (CompareTag("Shady") && SceneManager.GetActiveScene().buildIndex == 5)
        {
            Shady_Goral();
            return;
        }
        FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
        
    }

    private void Shady_Metro()
    {
        Debug.Log(PlayerStats.cans);
        if (PlayerStats.cans < 5)
        {
            Dialogue dialogue = new Dialogue();
            dialogue.NPCName = "Szemrany Jegomość";
            dialogue.sentences = new[] {"Oj szefuniu, cienko z kasą. Pogadamy jak znajdziesz więcej roppuszek."};
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
            PlayerStats.cans -= 5;
        }
    }

    private void Shady_Goral()
    {
        
    }
}
