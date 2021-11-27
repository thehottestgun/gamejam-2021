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
    
    public IEnumerator ChangeColor()
    {
        var color = _sr.color;
        bool stop = false;
        int iteracja = 0;
        while (!stop)
        {
            _sr.color = new Color(color.r += 0.2f, color.g-= 0.2f, color.b-= 0.2f);
            yield return new WaitForSeconds(0.1f);
            iteracja++;
            if (_sr.color.r >= 2)
                stop = true;
        }
        while (iteracja!=0)
        {
            _sr.color = new Color(color.r -= 0.2f, color.g+= 0.2f, color.b+= 0.2f);
            yield return new WaitForSeconds(0.1f);
            iteracja--;
        }
        StopCoroutine(ChangeColor());
    }
}
