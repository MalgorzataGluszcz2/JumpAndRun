using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public static EnemyHealthBar Instance;
    [SerializeField] Slider _healthSlider;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateHealthBar(float currentLife, float maxLife)
    { 
        _healthSlider.value = currentLife / maxLife;
    }
}
