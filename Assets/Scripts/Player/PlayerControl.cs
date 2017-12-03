﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 3.0f, bounceVelocity = 5.0f, dunkVelocity = 10.0f;

    private Rigidbody2D _rb;
    private bool _bounce = false, _active = true;
    private int _direction = 1, _starCount;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _starCount = PlayerPrefs.GetInt("Score");
    }

    // Perform all physics operations here to avoid bugs.
    private void LateUpdate()
    {
        _rb.velocity = new Vector2(speed * _direction, _rb.velocity.y);
        if (_bounce)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, bounceVelocity);
            _bounce = false;
        }
    }

    // Enemy and PowerUp collisions go here.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StarControl star = collision.GetComponent<StarControl>();
        if (star != null) _starCount++;
        EnemyTag enemy = collision.GetComponent<EnemyTag>();
        if (enemy != null)
        {
            Destroy(gameObject);
        }
    }

    // Tile bounce goes here.
    private void OnTriggerStay2D(Collider2D collision)
    {
        TileControl tc = collision.GetComponent<TileControl>();
        if (tc != null) _bounce = true;
    }

    // Tile collisions go here.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TileControl tc = collision.transform.gameObject.GetComponent<TileControl>();
        if (tc != null) tc.Damage();
    }

    // Input sends playing downwards.
    public void Dunk()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, -dunkVelocity);
    }

    // Returns true if player is active.
    public bool IsActive()
    {
        return _active;
    }

    // Same as above, but also sets active.
    public bool IsActive(bool set)
    {
        _active = set;
        return _active;
    }

    // Change direction of bounce.
    public void ChangeDirection()
    {
        _direction *= -1;
    }

    // Returns current score.
    public int GetScore()
    {
        return _starCount;
    }
}
