using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaControl : MonoBehaviour
{
    private float _initialX, _initialY;
    private int _direction;
    private float _timer = 0.0f;

    public float rotateSpeed = 1.0f;
    public bool enableSway = false, reverseDirection = false;
    public enum Direction { Horizontal, Vertical };
    public Direction swayDirection = Direction.Vertical;
    public float swayDistance = 1.0f, swayDelay = 1.0f;

    private void Start()
    {
        if (reverseDirection) _direction = -1;
        else _direction = 1;
        _initialX = transform.position.x;
        _initialY = transform.position.y;

    }

    private void Update()
    {
        transform.Rotate(0.0f, 0.0f, Time.deltaTime * -100.0f * rotateSpeed);

        _timer += Time.deltaTime;
        if (reverseDirection) _direction = -1;
        else _direction = 1;

        if (enableSway)
        {
            if (swayDirection == Direction.Horizontal)
            {
                transform.position = new Vector3(
                _initialX + (_direction * Mathf.PingPong(_timer / swayDelay, swayDistance)),
                transform.position.y);
            }

            else
            {
                transform.position = new Vector3(
                transform.position.x,
                _initialY + (_direction * Mathf.PingPong(_timer / swayDelay, swayDistance)));
            }
        }
    }
}
