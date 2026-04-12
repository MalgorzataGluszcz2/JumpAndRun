using UnityEngine;

public class SmallDiamond : MonoBehaviour
{
    [SerializeField] float _smallDiamondScore = 5f;
    [SerializeField] float _smallDiamondsMaxScore = 20f;

    void Start()
    {
        ScoreBar.Instance.ScoreBarUpdate(0f, _smallDiamondsMaxScore);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(_smallDiamondScore);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
