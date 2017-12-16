using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DebugControl : MonoBehaviour
{
    public InputField inputField;
    public Text inputResult;

    public void Start()
    {
        inputResult.text = "";
        //Adds a listener that invokes the "LockInput" method when the player finishes editing the main input field.
        //Passes the main input field into the method when "LockInput" is invoked
        inputField.onEndEdit.AddListener(delegate { LockInput(inputField); });
    }

    // Checks if there is anything entered into the input field.
    void LockInput(InputField input)
    {
        if (input.text.Length > 0)
        {
            int i;
            int.TryParse(input.text, out i);
            if ((i < SceneManager.sceneCountInBuildSettings - 1) && (i > 0))
            {
                PlayerPrefs.SetInt("Level", (i - 1) * 5 + 1);
                SceneManager.LoadScene(i);
            }
            else inputResult.text = "Invalid Scene Number.";
        }
        else if (input.text.Length == 0)
        {
            inputResult.text = "";
            Debug.Log("Main Input Empty");
        }
    }
}
