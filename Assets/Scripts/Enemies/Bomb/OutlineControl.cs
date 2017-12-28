using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineControl : MonoBehaviour
{
    private float _initialSize;
    private bool _trigger = false, _doOnce = true;
    public float explosionSpeed = 7.5f, fadeSpeed = 1.0f;

    private void Start()
    {
        _initialSize = transform.localScale.x;
        transform.localScale = Vector3.one * 0.1f;
    }

    private void Update()
    {
        if (_trigger && _doOnce)
        {
            StartCoroutine(GrowUp());
            _doOnce = false;
        }
    }

    public void Trigger()
    {
        _trigger = true;
    }

    private IEnumerator GrowUp()
    {
        while (transform.localScale.x < _initialSize)
        {
            transform.localScale += Vector3.one * Time.deltaTime * explosionSpeed;
            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        Renderer renderer = GetComponent<Renderer>();
        float change;
        change = 0.0f;
        while (change < 1.0f)
        {
            change += fadeSpeed * Time.deltaTime;
            renderer.material.color =
                new Color(1.0f, 1.0f, 1.0f, change);
            yield return null;
        }
    }
}
