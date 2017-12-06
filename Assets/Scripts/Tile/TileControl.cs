using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileControl : MonoBehaviour
{
    public bool unbreakable = false;
    public enum Range { Low, Medium, High };
    public Range lifeRange = Range.Low;
    public int lowMin = 2, mediumMin = 9, highMin = 17, highMax = 32;

    private int _life;
    private TextMesh[] _text;

	private void Start()
	{
        switch (lifeRange)
        {
            case Range.Low:
                _life = Random.Range(lowMin, mediumMin - 1);
                break;
            case Range.Medium:
                _life = Random.Range(mediumMin, highMin - 1);
                break;
            case Range.High:
                _life = Random.Range(highMin, highMax);
                break;
        }
        _text = GetComponentsInChildren<TextMesh>();
	}
	
	private void Update()
	{
        if (!unbreakable) for (int i = 0; i < _text.Length; i++) _text[i].text = _life.ToString();
        else for (int i = 0; i < _text.Length; i++) _text[i].text = "";
        if (_life <= 0 && !unbreakable) Destroy(gameObject);
	}

    public void Damage()
    {
        if (!unbreakable) _life--;
    }
}
