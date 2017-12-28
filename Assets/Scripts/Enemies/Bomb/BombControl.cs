using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControl : MonoBehaviour
{
    private TextMesh _text;
    private float _timer, _initialY;
    private bool _collided = false, _triggered = false;
    [SerializeField] private ExplosionControl _explosionPrefab;

    public enum Position { Up, Middle, Down };
    public Position relativePosition = Position.Middle;
    public float explosionDelay = 3.0f, explosionRadius = 3.0f, explosionYOffset = -0.115f;
    public bool enableSway = false;
    public float swayDistance = 0.1f, swayDelay = 10.0f;

    private void Start()
    {
        _text = GetComponentInChildren<TextMesh>();
        _timer = explosionDelay;
        _initialY = transform.position.y;
        _text.text = "";
    }

    private void Update()
    {
        if (_triggered)
        {
            if (_timer > 0) _timer -= Time.deltaTime;
            if (_timer < 0 || _collided)
            {
                _timer = 0.0f;
                ExplosionControl explosion = Instantiate(_explosionPrefab, transform.parent.position, Quaternion.identity);
                explosion.transform.position += Vector3.up * explosionYOffset;
                explosion.transform.parent = transform.parent;
                explosion.Explode(explosionRadius);
                Destroy(gameObject);
            }
            _text.text = _timer.ToString("0");
        }

        if (enableSway) transform.position = new Vector3(
            transform.position.x,
            _initialY + Mathf.PingPong(Time.time / swayDelay, swayDistance));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerControl player = collision.GetComponent<PlayerControl>();
        if (player != null) _collided = true;
    }

    public void Trigger()
    {
        _triggered = true;
    }
}
