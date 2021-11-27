using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLogic : Interaction
{
    private Animator _faderAnimator;

    private void Start()
    {
        _faderAnimator = GameObject.Find("Fader").GetComponent<Animator>();
    }

    private void Update()
    {
        Interact();
        
    }

    protected override void Interact()
    {
        if (_inRange && Input.GetButtonDown("Interaction"))
        {
            FaderSceneProgress.progressToNextScene = true;
            _faderAnimator.SetBool("Fading", true);
        }  
    }
}
