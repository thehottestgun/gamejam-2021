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
        _inRange = true;
        if (CompareTag("Finish") && SceneManager.GetActiveScene().buildIndex == 6)
        {
            
            StartCoroutine("TeleportToFarm");
            return;
        }
        
        if (CompareTag("Money") && other.CompareTag("Player") && PlayerStats.cans == 1 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
            if(!(clip.Length>0)) return;
            AudioSource.PlayClipAtPoint(clip[0],transform.position,1);
            return;
        }

        if (CompareTag("Health") && SceneManager.GetActiveScene().buildIndex == 2)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
            if(!(clip.Length>0)) return;
            AudioSource.PlayClipAtPoint(clip[0],transform.position,1);
            return;
        }
        if(!CompareTag("Finish"))
            GameObject.Find("InteractionMarker").GetComponent<SpriteRenderer>().enabled = true;
        
        
    }

    

    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject.Find("InteractionMarker").GetComponent<SpriteRenderer>().enabled = false;
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
        if (DialogueManager.endGame && CompareTag("Fridge"))
        {
            Dialogue dialogue = new Dialogue();
            dialogue.sentences = new[] {"Ech, to by?? d??ugi dzie??. Pora na wyczekiwane kakao.", "No nie wierz??! Migda??owe?!"};
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            return;
        }
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
            dialogue.NPCName = "Szemrany Jegomo????";
            dialogue.sentences = new[] {"Oj szefuniu, cienko z kas??. Pogadamy jak znajdziesz wi??cej roppuszek."};
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
        }
    }

    private void Shady_Goral()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
    }

    IEnumerator TeleportToFarm()
    {
        yield return new WaitForSecondsRealtime(3f);
        FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
        yield return new WaitForSecondsRealtime(5f);
        AudioSource.PlayClipAtPoint(clip[1],transform.position,1);
        SceneManager.LoadScene(7);
    }
}
