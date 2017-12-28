using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateControl : MonoBehaviour
{
    public float rotateSpeed = 5.0f;
    public enum Direction { Clockwise, Counterclockwise };
    public Direction rotateDirection = Direction.Clockwise;

    private void Update()
    {
        if (rotateDirection == Direction.Clockwise)
            transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
        else transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

}
