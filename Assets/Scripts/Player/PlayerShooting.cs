using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform _firePoint;

    public float _bulletSpeed = 10f;
    public float _fireRate = 0.2f;

    private float _nextFireTime;

    void Update()
    {
        Aim();
        if (Input.GetMouseButton(0) && Time.time >= _nextFireTime)
        { 
            _nextFireTime = Time.time * _fireRate;
            Shoot();
        }
    } 

    void Aim() 
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.z = 0;
        Vector2 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate only weapon
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.z = 0f;

        Vector2 direction = (mousePos - _firePoint.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity);

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.linearVelocity = direction * _bulletSpeed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
