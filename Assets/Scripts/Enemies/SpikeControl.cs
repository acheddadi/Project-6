using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeControl : MonoBehaviour
{
    private float _initialX;

    public bool enableSway = false;
    public float swayDistance = 0.5f, swayDelay = 10.0f;

    private void Start()
    {
        _initialX = transform.position.x;
    }

    private void Update()
    {
        if (enableSway) transform.position = new Vector3(
            _initialX + Mathf.PingPong(Time.time / swayDelay, swayDistance),
            transform.position.y);
    }
}
