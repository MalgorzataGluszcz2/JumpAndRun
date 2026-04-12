using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _runMultiplyer = 2f;
    [SerializeField] float _jumpPower = 8f;

    [SerializeField] float _playerHealth = 10f;

    [SerializeField] Transform _groundCheck;
    [SerializeField] LayerMask _groundLayerMask;

    float _horizontalMovement;
    bool _isFaceingRight = true;
    bool _isRunning;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal");
        _isRunning = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.x, _jumpPower);
        }

        if (Input.GetButtonUp("Jump") && _rigidbody2D.linearVelocity.y > 0f)
        {
            _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.x, _rigidbody2D.linearVelocity.y * 0.5f);
        }

        FlipPlayerSprite();
    }

    void FixedUpdate()
    {
        Move();
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayerMask);
    }

    void Move()
    {
        float speed = _moveSpeed;

        if (_isRunning)
        {
            speed *= _runMultiplyer;
        }

        _rigidbody2D.linearVelocity = new Vector2(_horizontalMovement * speed, _rigidbody2D.linearVelocity.y);
        _animator.SetBool("isWalking", _horizontalMovement != 0);
        _animator.SetBool("isRunning", _isRunning && _horizontalMovement != 0);
    }

    void FlipPlayerSprite()
    {
        if (_isFaceingRight && _horizontalMovement < 0f || !_isFaceingRight && _horizontalMovement > 0f)
        {
            _isFaceingRight = !_isFaceingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}