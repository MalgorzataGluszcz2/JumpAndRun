using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour 
{
    HealthBar _healthBar;
    [SerializeField] int _maxHealth = 10;
    int _currentHealth;

    void Start()
    {
        _currentHealth = _maxHealth;
        HealthBar.Instance.HealthBarUpdate(_currentHealth, _maxHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthBar.Instance.HealthBarUpdate(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            // Game Over Screen

            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}