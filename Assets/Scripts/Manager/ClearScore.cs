using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScore : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Level", 1);
    }
}
