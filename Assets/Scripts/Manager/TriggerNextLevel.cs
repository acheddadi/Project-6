using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerNextLevel : MonoBehaviour
{
    private FadeControl _fade;
    private bool _nextLevel = false;

    private void Start()
    {
        _fade = GetComponent<FadeControl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl player = collision.GetComponent<PlayerControl>();
        if (player != null)
        {
            PlayerPrefs.SetInt("Score", player.GetScore());
            _nextLevel = true;
        }
    }

    public bool NextLevel()
    {
        return _nextLevel;
    }
}
