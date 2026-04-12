using UnityEngine;

public class BgParallax : MonoBehaviour
{
    private float _startPos, _length; // It's the initial position of the background
    [SerializeField] GameObject _camera;
    [SerializeField] float _paralaxSpeedEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startPos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculate distance bg move based on camera movement
        float distance = _camera.transform.position.x * _paralaxSpeedEffect;
        float movement = _camera.transform.position.x * (1 - _paralaxSpeedEffect);

        transform.position = new Vector3(_startPos + distance, transform.position.y, transform.position.z);

        // If background has reached the end of it's length adjust it's posiiton for infinite scrolling 
        if (movement > _startPos + _length)
        {
            _startPos += _length;
        }
        else if (movement < _startPos - _length)
        {
            _startPos -= _length;
        }
    }
}
