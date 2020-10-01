using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _exit;
    [SerializeField] private Player _player;

    private bool _playerIsEnter = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && _playerIsEnter == true)
        {
            _player.transform.position = _exit.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _playerIsEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _playerIsEnter = false;
        }
    }
}
