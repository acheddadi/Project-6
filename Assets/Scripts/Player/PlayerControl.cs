using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 3.0f, bounceVelocity = 5.0f, dunkVelocity = 10.0f;

    private Rigidbody2D _rb;
    private bool _bounce = false, _active = true;
    private int _direction = 1, _starCount = 0;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        _rb.velocity = new Vector2(speed * _direction, _rb.velocity.y);
        if (_bounce)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, bounceVelocity);
            _bounce = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StarControl star = collision.GetComponent<StarControl>();
        if (star != null) _starCount++;
        EnemyTag enemy = collision.GetComponent<EnemyTag>();
        if (enemy != null)
        {
            transform.position = transform.parent.position;
            _rb.velocity = new Vector2(0.0f, 0.0f);
            _direction = 1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        TileControl tc = collision.GetComponent<TileControl>();
        if (tc != null) _bounce = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TileControl tc = collision.transform.gameObject.GetComponent<TileControl>();
        if (tc != null) tc.Damage();
    }

    public void Dunk()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, -dunkVelocity);
    }

    public bool IsActive()
    {
        return _active;
    }

    public bool IsActive(bool set)
    {
        _active = set;
        return _active;
    }

    public void ChangeDirection()
    {
        _direction *= -1;
    }

    public int GetScore()
    {
        return _starCount;
    }
}
