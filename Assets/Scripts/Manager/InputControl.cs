using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    public float clickDelay = 0.1f, slideDelay = 0.5f;

    [SerializeField] private Transform _playerParent;
    private float _timer, _slideTimer;
    private FadeControl _fade;

	private void Start()
	{
        _fade = GetComponent<FadeControl>();
        _timer = Time.time;
        _slideTimer = slideDelay;
        //Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }

        if (_playerParent != null)
        {
            PlayerControl player = _playerParent.GetComponentInChildren<PlayerControl>();
            if (player == null)
            {
                StartCoroutine(_fade.RestartLevel());
            }
        }

        if (_playerParent != null)
        {
            PlayerControl player = _playerParent.GetComponentInChildren<PlayerControl>();
            if (player != null)
            {
                if (player.IsActive())
                {
                    if (Input.GetMouseButton(0))
                    {
                        _slideTimer += Time.deltaTime;
                        if (_slideTimer > slideDelay)
                        {
                            player.Slide(true);
                            _slideTimer = 0.0f;
                        }
                    }
                    else player.Slide(false);
                }
            }
        }
    }

    // Perform physics operation here to avoid bugs.
    private void LateUpdate()
	{
        // Dunk on click, while respecting click delay. Cannot dunk if player is missing.
		if (Input.GetMouseButtonDown(0) && (Time.time > _timer + clickDelay) && (_playerParent != null))
        {
            PlayerControl player = _playerParent.GetComponentInChildren<PlayerControl>();
            if (player != null)
            {
                if (player.IsActive()) player.Dunk();
            }
            _timer = Time.time;
        }
	}
}
