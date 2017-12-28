using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseControl : MonoBehaviour
{
    private float _initialX, _initialY, _oldX, _timer, _initialScaleX, _spriteOrientation;
    private int _direction = 1;

    public bool reverseDirection = false;
    public float ellipseWidth = 1.0f, ellipseHeight = 1.0f, speed = 1.0f, spriteFlipDelay = 2.0f;

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

        transform.localScale = new Vector3(_initialScaleX * _spriteOrientation,
            transform.localScale.y, transform.localScale.z);

        transform.position = new Vector3(
            _initialX + ellipseWidth * Mathf.Sin(_direction * speed * _timer),
            _initialY + ellipseHeight * Mathf.Cos(_direction * speed * _timer));

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
