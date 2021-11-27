using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f, jumpForce = 5.0f;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _sprite;

    private bool _canJump = true;
    private Animator _playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        var xDisplacement = Input.GetAxis("Horizontal");
        _playerAnimator.SetFloat("speed",Math.Abs(xDisplacement));
        _sprite.flipX = xDisplacement < 0;
        _rigidbody.velocity = new Vector2(xDisplacement * speed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (!Input.GetButton("Jump") || !_canJump) return;
        Debug.Log("Jumping");
        _canJump = false;
        _rigidbody.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor") && other.GetContact(0).normal.y == 1)
        {
            _canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            _canJump = false;
        }
    }
}
