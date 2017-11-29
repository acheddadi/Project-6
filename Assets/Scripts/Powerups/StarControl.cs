using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarControl : MonoBehaviour
{
    private float _initialY;

    public bool enableSway = false;
    public float swayDistance = 0.5f, swayDelay = 10.0f;

    private void Start()
    {
        _initialY = transform.position.y;
    }

    private void Update()
	{
        if (enableSway) transform.position = new Vector3(
            transform.position.x,
            _initialY + Mathf.PingPong(Time.time / swayDelay, swayDistance));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl player = collision.GetComponent<PlayerControl>();
        if (player != null) Destroy(gameObject);
    }
}
