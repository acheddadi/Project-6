using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWrap : MonoBehaviour
{
    private bool _wrap = false;
    private Collider2D _collision;

    private void LateUpdate()
    {
        if (_wrap && (_collision != null))
        {
            _collision.transform.position = new Vector3(-_collision.transform.position.x, _collision.transform.position.y, _collision.transform.position.z);
            _wrap = false;
            _collision = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl player = collision.GetComponent<PlayerControl>();
        if (player != null)
        {
            player.IsActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerControl player = collision.GetComponent<PlayerControl>();
        if (player != null)
        {
            player.IsActive(true);
        }
        _wrap = true;
        _collision = collision;
    }
}
