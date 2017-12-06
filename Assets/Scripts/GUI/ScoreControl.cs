using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    [SerializeField] private PlayerControl _player;
    [SerializeField] private Text _score;
    [SerializeField] private Text _level;
	
    // Display score.
	private void Update()
	{
        if (_score == null || _level == null) Debug.LogError("ScoreControl : You forgot to assign a text object.");
        else
        {
            _score.text = _player.GetScore().ToString("D2");
            _level.text = _player.GetLevel().ToString("D2");
        }
	}
}
