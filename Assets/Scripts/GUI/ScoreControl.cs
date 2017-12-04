using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    [SerializeField] private PlayerControl _player;
    [SerializeField] private Text _score, _level;
	
    // Display score.
	private void Update()
	{
        _score.text = _player.GetScore().ToString("D2");
        _level.text = _player.GetLevel().ToString("D2");
	}
}
