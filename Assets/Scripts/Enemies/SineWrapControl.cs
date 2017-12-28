using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWrapControl : MonoBehaviour
{
    private Renderer _renderer;
    private float _initialY;
    private int _direction;
    private float _sineTimer = 0.0f;
    private bool _wrapping = false;

    public bool cosine = false, reverseDirection = false;
    public float travelSpeed = 1.0f, swayDistance = 0.5f, swayDelay = 2.0f;


    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        if (reverseDirection) _direction = -1;
        else _direction = 1;
        _initialY = transform.position.y;
    }

    private void Update()
    {
        _sineTimer += Time.deltaTime;

        if (reverseDirection) _direction = -1;
        else _direction = 1;

        if (!_wrapping && !_renderer.isVisible)
        {
            Renderer renderer = GetComponent<Renderer>();
            transform.position = new Vector3(transform.position.x * -1, transform.position.y);
            _wrapping = true;
        }
        else _wrapping = false;

        transform.position = new Vector3(
            transform.position.x + (_direction * travelSpeed * Time.deltaTime),
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
    }
}
