using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieControl : MonoBehaviour
{
    private bool _stepInProgress = false;

    public bool reverseDirection = false;
    public int dieNumber = 1;
    public float rotationSpeed = 1.0f;
    public Transform[] fourCorners = new Transform[4];

    private void Update()
    {
        if (!_stepInProgress)
        {
            if (reverseDirection) StartCoroutine(ReverseDieStep());
            else StartCoroutine(DieStep());
        }
    }

    private IEnumerator RotateAbout(int index, int direction)
    {
        float rotation = 0.0f;
        while (rotation < 90.0f)
        {
            rotation += rotationSpeed * 90.0f * Time.deltaTime;

            if (rotation > 90.0f)
            {
                float lastRotation = 90.0f - (rotation - rotationSpeed * 90.0f * Time.deltaTime);
                transform.RotateAround(
                fourCorners[index].position,
                Vector3.forward,
                direction * lastRotation);
            }

            else transform.RotateAround(
                fourCorners[index].position,
                Vector3.forward,
                direction * rotationSpeed * 90.0f * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator ReverseDieStep()
    {
        _stepInProgress = true;
        int lastCorner = 0;
        for (int i = 0; i < dieNumber; i++, lastCorner++)
        {
            if (lastCorner > fourCorners.Length - 1) lastCorner = 0;
            yield return StartCoroutine(RotateAbout(lastCorner, 1));
        }
        lastCorner--;
        for (int i = 0; i < dieNumber; i++, lastCorner--)
        {
            if (lastCorner < 0) lastCorner = fourCorners.Length - 1;
            yield return StartCoroutine(RotateAbout(lastCorner, -1));
        }
        _stepInProgress = false;
    }

    private IEnumerator DieStep()
    {
        _stepInProgress = true;
        int lastCorner = fourCorners.Length - 1;
        for (int i = 0; i < dieNumber; i++, lastCorner--)
        {
            if (lastCorner < 0) lastCorner = fourCorners.Length - 1;
            yield return StartCoroutine(RotateAbout(lastCorner, -1));
        }
        lastCorner++;
        for (int i = 0; i < dieNumber; i++, lastCorner++)
        {
            if (lastCorner > fourCorners.Length - 1) lastCorner = 0;
            yield return StartCoroutine(RotateAbout(lastCorner, 1));
        }
        _stepInProgress = false;
    }
}
