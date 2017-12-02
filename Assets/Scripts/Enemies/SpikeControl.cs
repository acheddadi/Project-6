using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeControl : MonoBehaviour
{
    private float _initialX;
    private int _direction;

    public bool enableSway = false, reverseDirection = false;
    public float swayDistance = 0.5f, swayDelay = 10.0f;

    private void Start()
    {
        _initialX = transform.position.x;
    }

    private void Update()
    {
        if (reverseDirection) _direction = -1;
        else _direction = 1;
        if (enableSway) transform.position = new Vector3(
            _initialX + (_direction * Mathf.PingPong(Time.time / swayDelay, swayDistance)),
            transform.position.y);
    }
}