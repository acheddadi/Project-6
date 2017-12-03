using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeControl : MonoBehaviour
{
    public Texture texture;
    public float fadeDelay = 0.8f;

    private TriggerNextLevel _trigger;
    private float _alpha = 1.0f;

    private void Start()
    {
        StartCoroutine(FadeIn());
        _trigger = GetComponent<TriggerNextLevel>();
    }

    private void Update()
    {
        if (_trigger.NextLevel())
        {
            StartCoroutine(NextLevel());
        }
    }

    private void OnGUI()
    {
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, _alpha);
        GUI.depth = -1000;
        GUI.DrawTexture(new Rect(0.0f, 0.0f, Screen.width, Screen.height), texture);
    }

    private IEnumerator FadeIn()
    {
        while (_alpha > 0.0f)
        {
            _alpha -= fadeDelay * Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        while (_alpha < 1.0f)
        {
            _alpha += fadeDelay * Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator NextLevel()
    {
        yield return StartCoroutine(FadeOut());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator RestartLevel()
    {
        yield return StartCoroutine(FadeOut());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
