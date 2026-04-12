using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float _maxHealth = 50f;
    float _currentHealth = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = _maxHealth;
        EnemyHealthBar.Instance.UpdateHealthBar(_currentHealth, _maxHealth);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10f);
        }
    }

    void TakeDamage(float damageValue)
    {
        _currentHealth -= damageValue;
        EnemyHealthBar.Instance.UpdateHealthBar(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
