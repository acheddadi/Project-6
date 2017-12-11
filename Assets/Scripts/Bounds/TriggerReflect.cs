using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReflect : MonoBehaviour
{
    private float _timer;

    public float reflectDelay = 0.5f;

    private void Start()
    {
        _timer = Time.time;
    }

    // Change direction when bounds are touched
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.time > _timer + reflectDelay)
        {
            PlayerControl player = collision.GetComponent<PlayerControl>();
            if (player != null && !collision.isTrigger) player.ChangeDirection();
            _timer = Time.time;
        }
        
    }
}
