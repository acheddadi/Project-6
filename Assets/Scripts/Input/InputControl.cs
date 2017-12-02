using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    [SerializeField] private Transform _playerParent;
    public float clickDelay = 0.1f;

    private float _timer;

	private void Start()
	{
        _timer = Time.time;
        //Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    // Perform physics operation here to avoid bugs.
    private void LateUpdate()
	{
        // Dunk on click, while respecting click delay. Cannot dunk if player is missing.
		if (Input.GetMouseButtonDown(0) && (Time.time > _timer + clickDelay) && (_playerParent != null))
        {
            PlayerControl player = _playerParent.GetComponentInChildren<PlayerControl>();
            if (player.IsActive()) player.Dunk();
            _timer = Time.time;
        }
	}
}
