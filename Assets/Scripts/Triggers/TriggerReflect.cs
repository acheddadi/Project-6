using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReflect : MonoBehaviour
{
    // Change direction when bounds are touched
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl player = collision.GetComponent<PlayerControl>();
        if (player != null) player.ChangeDirection();
    }
}
