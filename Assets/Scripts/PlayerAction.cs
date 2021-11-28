using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer _sr;
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(ChangeColor());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bulldog")||other.gameObject.CompareTag("Doberman"))
        {
            StartCoroutine(ChangeColor());
        }
    }


    public IEnumerator ChangeColor()
    {
        for (int i = 1; i < 4; i++)
        {
            _sr.color=Color.red;
            yield return new WaitForSeconds(0.1f+(float)i/10);
            _sr.color=Color.white;
            yield return new WaitForSeconds(0.1f+(float)i/10);
        }
        StopCoroutine(ChangeColor());
    }
}
