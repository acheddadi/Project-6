using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineControl : MonoBehaviour
{
    private CircleCollider2D _collider;
    private float _initialX, _initialY, _oldX;
    private int _direction;
    private float _timer = 0.0f, _sineTimer = 0.0f, _initialScaleX, _spriteOrientation;

    public bool cosine = false, reverseDirection = false;
    public float spriteFlipDelay = 2.0f, travelDistance = 1.0f, travelDelay = 1.0f, swayDistance = 0.5f, swayDelay = 2.0f;


    private void Start()
    {
        if (reverseDirection)
        {
            _direction = -1;
            _spriteOrientation = -1;
        }
        else
        {
            _direction = 1;
            _spriteOrientation = 1;
        }
        _initialX = transform.position.x;
        _initialY = transform.position.y;
        _initialScaleX = transform.localScale.x;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (reverseDirection) _direction = -1;
        else _direction = 1;

        transform.localScale = new Vector3(_initialScaleX * _spriteOrientation,
            transform.localScale.y, transform.localScale.z);

        transform.position = new Vector3(
            _initialX + (_direction * Mathf.PingPong(_timer / travelDelay, travelDistance)),
            transform.position.y);

        if (cosine)
        {
            transform.position = new Vector3(
            transform.position.x,
            _initialY + swayDistance * Mathf.Cos(_sineTimer * swayDelay));
        }
        else
        {
            transform.position = new Vector3(
            transform.position.x,
            _initialY + swayDistance * Mathf.Sin(_sineTimer * swayDelay));
        }

        if (_oldX < transform.position.x)
        {
            _sineTimer += Time.deltaTime;
            if (_spriteOrientation < 1) _spriteOrientation += Time.deltaTime * spriteFlipDelay;
        }
        else
        {
            _sineTimer -= Time.deltaTime;
            if (_spriteOrientation > -1) _spriteOrientation -= Time.deltaTime * spriteFlipDelay;
        }
        _oldX = transform.position.x;
    }
}
