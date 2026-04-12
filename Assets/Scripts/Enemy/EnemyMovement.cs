using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject _pointA;
    [SerializeField] GameObject _pointB;

    [SerializeField] float _enemyMoveSpeed;
    
    Rigidbody2D _enemyRb2D;
    Animator _enemyAnim;
    Transform _currentPoint;

    void Start()
    {
        _enemyRb2D = GetComponent<Rigidbody2D>();
        _enemyAnim = GetComponent<Animator>();
        _currentPoint = _pointB.transform;
        _enemyAnim.SetBool("isEnemyWalking", true);
    }

    void Update()
    {
        Vector2 point = _currentPoint.position - transform.position;
        if (_currentPoint == _pointB.transform)
        {
            _enemyRb2D.linearVelocity = new Vector2(_enemyMoveSpeed, 0f);
        }
        else
        {
            _enemyRb2D.linearVelocity = new Vector2(-_enemyMoveSpeed, 0f);
        }

        if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == _pointB.transform)
        {
            EnemyFlip();
            _currentPoint = _pointA.transform;
        }

        if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == _pointA.transform)
        {
            EnemyFlip();
            _currentPoint = _pointB.transform;
        }
    }

    void EnemyFlip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(_pointB.transform.position, 0.5f);
        Gizmos.DrawLine(_pointA.transform.position, _pointB.transform.position);
    }
}