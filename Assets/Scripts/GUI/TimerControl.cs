using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerControl : MonoBehaviour
{
    private float _timer, _delay = 1.0f;
    private int _currentTime;
    private TextMesh _text;

    public int time = 60;

	private void Start()
	{
        _text = GetComponent<TextMesh>();
        _currentTime = time;
        _text.text = _currentTime.ToString("D2");
	}
	
	private void Update()
	{
		if ((Time.time > _timer + _delay) && (_currentTime > 0))
        {
            _currentTime--;
            _text.text = _currentTime.ToString("D2");
            _timer = Time.time;
        }

        else if (_currentTime <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
	}
}
