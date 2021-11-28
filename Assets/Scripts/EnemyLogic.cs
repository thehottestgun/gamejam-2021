using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform _player;
    private Transform _enemy;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    private Animator _an;
    private bool _isNotAttacking;
    
    public int speed;
    public int enemyRangeX;
    public int enemyRangeY;
    
    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _sr = GetComponent<SpriteRenderer>();
        _an = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _isNotAttacking = true;
        _enemy = gameObject.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        Chase();    
    }

    private void Chase()
    {
        if ((Math.Abs(_player.position.x - _enemy.position.x) < enemyRangeX || Math.Abs(_player.position.y - _enemy.position.y) < enemyRangeY)&&_isNotAttacking)
        {
            _an.SetFloat("Speed",speed);
            if (_player.position.x > _enemy.position.x)
            {
                _enemy.Translate(new Vector2(speed*Time.deltaTime,0));
                _sr.flipX = true;
            }
            else
            {
                _enemy.Translate(new Vector2(-speed*Time.deltaTime,0));
                _sr.flipX = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isNotAttacking = false;
            _an.SetBool("CanAttack",true);
        }

        
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isNotAttacking = true;
            _an.SetBool("CanAttack",false);
        }
    }
}
