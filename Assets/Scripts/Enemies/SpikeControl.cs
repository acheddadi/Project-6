using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeControl : MonoBehaviour
{
    private float _initialX;
    private int _direction;
    private float _timer = 0.0f;

    public bool enableSway = false, reverseDirection = false, randomPosition = false;
    public float swayDistance = 0.5f, swayDelay = 10.0f;

    private void Start()
    {
        if (reverseDirection) _direction = -1;
        else _direction = 1;
        _initialX = transform.position.x;
        if (randomPosition)
        {
            CircleCollider2D circle = GetComponent<CircleCollider2D>();
            Collider2D collider;
            do
            {
                if (!enableSway) _initialX = Random.Range(-2.5f, 2.5f);
                else
                {
                    if (_direction > 0) _initialX = Random.Range(-2.5f, 2.5f - swayDistance);
                    else _initialX = Random.Range(-2.5f + swayDistance, 2.5f);
                }
                collider = Physics2D.OverlapCircle(new Vector2(_initialX, transform.position.y), circle.radius);
            } while (collider != null);
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (reverseDirection) _direction = -1;
        else _direction = 1;
        if (enableSway) transform.position = new Vector3(
            _initialX + (_direction * Mathf.PingPong(_timer / swayDelay, swayDistance)),
            transform.position.y);
    }
}