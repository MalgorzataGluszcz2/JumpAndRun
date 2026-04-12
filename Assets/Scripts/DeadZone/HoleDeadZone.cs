using UnityEngine;

public class HoleDeadZone : MonoBehaviour
{
    [SerializeField] Health _playerHealth;
    //Vector2 spawnPoint = new Vector2(-2.66, -1,33);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerHealth.TakeDamage(3);
            collision.transform.position = new Vector2(-2.66f, -1.33f);
        }
    }
}