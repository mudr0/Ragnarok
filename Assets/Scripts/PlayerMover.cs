using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _layerMask;

    private Player _player;
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Move(false, 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(true, -1);
        }
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.velocity = Vector2.up * _jumpForce;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            _player.ChangeHealth(-10);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            _player.ChangeHealth(10);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.down, 0.15f, _layerMask);
        return raycastHit.collider != null;
    }

    private void Move(bool xAnimationFlip, int direction)
    {
        transform.Translate(new Vector3(_speed * Time.deltaTime * direction, 0, 0));
    }
}
