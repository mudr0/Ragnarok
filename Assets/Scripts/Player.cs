using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;
    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ChangeHealth(int change)
    {
        _currentHealth += change;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}
