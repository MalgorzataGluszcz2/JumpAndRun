using UnityEngine;

public class BigDiamond : MonoBehaviour
{
    [SerializeField] float _bigDiamondScore = 10f;
    [SerializeField] float _bigsDiamondsMaxScore = 20f;

    void Start()
    {
        ScoreBar.Instance.ScoreBarUpdate(0f, _bigsDiamondsMaxScore);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(_bigDiamondScore);
            gameObject.SetActive(false);
            Destroy(gameObject); 
        }
    }
}
