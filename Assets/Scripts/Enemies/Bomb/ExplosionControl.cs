using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionControl : MonoBehaviour
{
    public float explosionSpeed = 3.0f, fadeSpeed = 2.0f;

    public void Explode(float size)
    {
        StartCoroutine(GrowUp(size));
    }

    private IEnumerator GrowUp(float size)
    {
        while (transform.localScale.x < size)
        {
            transform.localScale += Vector3.one * Time.deltaTime * explosionSpeed;
            yield return null;
        }
        Transform oldParent = transform.parent;
        transform.parent = oldParent.transform.parent;
        Destroy(oldParent.gameObject);
        yield return StartCoroutine(FadeOut());
        Destroy(gameObject);
    }

    private IEnumerator FadeOut()
    {
        Renderer renderer = GetComponent<Renderer>();
        float change;
        change = 1.0f;
        while (change > 0.0f)
        {
            change -= fadeSpeed * Time.deltaTime;
            renderer.material.color =
                new Color(1.0f, 1.0f, 1.0f, change);
            yield return null;
        }
    }
}
