using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemniscateControl : MonoBehaviour
{
    private float _initialX, _initialY, _initialScaleX, _oldX, _timer = 0.0f, _spriteOrientation;
    private int _direction;

    public bool reverseDirection = false;
    public enum Direction { Horizontal, Vertical };
    public Direction swayDirection = Direction.Horizontal;
    public float speed = 1.0f, size = 1.0f, spriteFlipDelay = 2.0f;

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

        if (swayDirection == Direction.Horizontal)
        {
            transform.position = new Vector3(
            _initialX + _direction * (size * Mathf.Sqrt(2) * Mathf.Cos(_timer * speed)) /
            (Mathf.Pow(Mathf.Sin(_timer * speed), 2) + 1),
            _initialY + _direction * (size * Mathf.Sqrt(2) * Mathf.Cos(_timer * speed) * Mathf.Sin(_timer * speed)) /
            (Mathf.Pow(Mathf.Sin(_timer * speed), 2) + 1));
        }

        else
        {
            transform.position = new Vector3(
            _initialX + _direction * (size * Mathf.Sqrt(2) * Mathf.Cos(_timer * speed) * Mathf.Sin(_timer * speed)) /
            (Mathf.Pow(Mathf.Sin(_timer * speed), 2) + 1),
            _initialY + _direction * (size * Mathf.Sqrt(2) * Mathf.Cos(_timer * speed)) /
            (Mathf.Pow(Mathf.Sin(_timer * speed), 2) + 1));
        }

        if (_oldX < transform.position.x)
        {
            if (_spriteOrientation < 1) _spriteOrientation += Time.deltaTime * spriteFlipDelay;
        }
        else
        {
            if (_spriteOrientation > -1) _spriteOrientation -= Time.deltaTime * spriteFlipDelay;
        }
        _oldX = transform.position.x;
    }
}
