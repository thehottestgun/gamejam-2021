using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform _player;
    private Transform _enemy;
    private Rigidbody2D _playerRb;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _enemy = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Chase();    
    }

    private void Chase()
    {
        if (Math.Abs(_player.position.x - _enemy.position.x) < 2 || Math.Abs(_player.position.y - _enemy.position.y) < 2)
        {
            Debug.Log("Enemy Chase");
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_player.position.x > _enemy.position.x)
            {
                Debug.Log("Player Get Damage");
            }
            else
            {
                Debug.Log("Player Get Damage");
            }
        }
    }
}
