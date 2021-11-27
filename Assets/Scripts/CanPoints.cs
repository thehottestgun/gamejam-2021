using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanPoints : MonoBehaviour
{
    [SerializeField] private AudioClip _audio;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            PlayerStats.cans++;
           AudioSource.PlayClipAtPoint(_audio,transform.position,1);
           
            
           UIUpdate.instance.SetCans(PlayerStats.cans);
           Destroy(gameObject);
        }
    }
}
