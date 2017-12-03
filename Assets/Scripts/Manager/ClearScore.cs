using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScore : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.DeleteKey("Score");
    }
}
