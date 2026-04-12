using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar Instance;
    [SerializeField] Slider _healthSlider;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void HealthBarUpdate(int currentHealth, int maxHealth)
    {
        _healthSlider.value = currentHealth / maxHealth;
    }
}