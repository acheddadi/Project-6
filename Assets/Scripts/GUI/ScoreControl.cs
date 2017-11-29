using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    [SerializeField] private PlayerControl _player;
    [SerializeField] private Text _text;

	private void Start()
	{
		
	}
	
	private void Update()
	{
        _text.text = _player.GetScore().ToString("D2");
	}
}
