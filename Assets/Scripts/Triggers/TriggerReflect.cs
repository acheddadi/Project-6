using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReflect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl player = collision.GetComponent<PlayerControl>();
        if (player != null) player.ChangeDirection();
    }
}
