using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTriggerControl : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerControl player = collision.GetComponent<PlayerControl>();
        if (player != null)
        {
            BombControl bomb = transform.parent.GetComponentInChildren<BombControl>();
            switch (bomb.relativePosition)
            {
                case BombControl.Position.Up:
                    if (player.transform.position.y < bomb.transform.position.y)
                        StartCoroutine(StartSequence());
                    break;
                case BombControl.Position.Middle:
                    StartCoroutine(StartSequence());
                    break;
                case BombControl.Position.Down:
                    if (player.transform.position.y > bomb.transform.position.y)
                        StartCoroutine(StartSequence());
                    break;
            }
        }
    }

    private IEnumerator StartSequence()
    {
        OutlineControl outline = GetComponentInChildren<OutlineControl>();
        if (outline != null) outline.Trigger();

        yield return new WaitForSeconds(0.25f);

        BombControl bomb = transform.parent.GetComponentInChildren<BombControl>();
        if (bomb != null) bomb.Trigger();
    }
}
