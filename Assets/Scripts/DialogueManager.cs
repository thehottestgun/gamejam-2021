using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> _sentences;

    private bool _inDialogue;

    private TMP_Text _dialogueBox;

    private Animator _dialogueBoxAnimator, _faderAnimator;
    private string _nameToPass;
    private int _counter = 0;

    public static bool endGame;
    [SerializeField] private AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        _sentences = new Queue<string>();
        _inDialogue = false;
        _dialogueBoxAnimator = GameObject.Find("Dialogue Box").GetComponent<Animator>();
        _dialogueBox = GameObject.Find("Dialogue Box").GetComponentInChildren<TextMeshProUGUI>();
        

        Debug.Log(_dialogueBox.text);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Confirm") && _inDialogue)
        {
            Debug.Log(_sentences.Count);
            DisplayNextSentence(_nameToPass);
        }
    }

    private void OnEnable()
    {
        if (endGame)
        {
            Dialogue dia = new Dialogue();
            dia.sentences = new[] {"Jezus Maria, ja tylko chciałem kupić mleko."};
            StartDialogue(dia);
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        
        Debug.Log("Starting conversation with " + dialogue.NPCName);
        
        _inDialogue = true;
        
        _sentences.Clear();
        
        foreach (var sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }
        Debug.Log(dialogue.sentences[0]);
        _dialogueBoxAnimator.SetBool("InDialogue",true);
        _nameToPass = String.IsNullOrEmpty(dialogue.NPCName) ? null : dialogue.NPCName;
        DisplayNextSentence(_nameToPass);
    }

    public void DisplayNextSentence(string name)
    {
        if (_sentences.Count == 0)
        {
            _inDialogue = false;
            EndDialogue(name);
            return;
        }
        
        var currentName = PlayerStats.name;
        if (name != null)
        {
             currentName = _counter % 2 != 0 ?  PlayerStats.name : name;
        }
        var sentence = _sentences.Dequeue();
        _dialogueBox.text = "<b>" + currentName + "</b>" + "\n" + sentence;
        _counter++;
    }

    void EndDialogue(string name)
    {
        _dialogueBoxAnimator.SetBool("InDialogue",false);
        _dialogueBox.text = "";
        _counter = 0;
        if (name != null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 7)
            {
                endGame = true;
                StartCoroutine("FinishTP");
                return;
            }

            
            
            FaderSceneProgress.progressToNextScene = true;
            GameObject.Find("Fader").GetComponent<Animator>().SetBool("Fading",true);
        }
        
        if (endGame && SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(8);
        }
        
        Debug.Log("End of conversation.");
    }

    IEnumerator FinishTP()
    {
        AudioSource.PlayClipAtPoint(clip,GameObject.Find("Player").transform.position,1);
        yield return new WaitForSecondsRealtime(.35f);
        SceneManager.LoadScene(1);
        StopCoroutine("FinishTP");
    }
}
