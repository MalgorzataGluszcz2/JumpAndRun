using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] float _score = 0f;
    [SerializeField] TMP_Text _scoreText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(float scoreValue)
    {
        _score += scoreValue;
        ScoreBar.Instance.ScoreBarUpdate(_score, 20f);
        //UpdateScoreUI();
    }

    //void UpdateScoreUI()
    //{
    //    if (_scoreText != null)
    //    {
    //        _scoreText.text = "Score: " + _score.ToString();
    //    }
    //}
}
