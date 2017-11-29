using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileControl : MonoBehaviour
{
    public int life = 22;

    private int _life;
    private TextMesh[] _text;

	private void Start()
	{
        _life = life;
        _text = GetComponentsInChildren<TextMesh>();
	}
	
	private void Update()
	{
        for (int i = 0; i < _text.Length; i++) _text[i].text = _life.ToString();
        if (_life <= 0) Destroy(gameObject);
	}

    public void Damage()
    {
        _life--;
    }
}
