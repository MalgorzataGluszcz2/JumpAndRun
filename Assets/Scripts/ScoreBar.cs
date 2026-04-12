using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public static ScoreBar Instance;

    [SerializeField] private Slider _scoreSlider;
    [SerializeField] private TMP_Text _scoreText;

    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public void ScoreBarUpdate(float currentScore, float maxScore)
    {
        _scoreSlider.maxValue = maxScore;
        _scoreSlider.value = currentScore;
        _scoreText.text = _scoreSlider.value + "/" + _scoreSlider.maxValue;
    }
}
