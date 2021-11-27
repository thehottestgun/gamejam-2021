using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private bool _inRange;
    
    public virtual void Interact()
    {
        if (_inRange && Input.GetButton("Interaction"))
        {
            Debug.Log("Interacted");
        }  
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _inRange = true;
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _inRange = false;
    }
}
