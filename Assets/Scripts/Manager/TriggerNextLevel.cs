using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerNextLevel : MonoBehaviour
{
    private bool _nextLevel = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl player = collision.GetComponent<PlayerControl>();
        if (player != null)
        {
            PlayerPrefs.SetInt("Score", player.GetScore());
            PlayerPrefs.SetInt("Level", player.GetLevel());
            _nextLevel = true;
        }
    }

    public bool NextLevel()
    {
        return _nextLevel;
    }
}
