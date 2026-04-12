using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public Weapon currentWeapon;
    public Transform firePoint;

    private Bulllet bulletScript;
    private float nextFireTime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + currentWeapon.fireRate;
            Shoot();
        }
    }

    void Shoot()
    { 
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector3 direction = (mousePos - firePoint.position).normalized;
        GameObject bullet = Instantiate(currentWeapon.bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb2D = bullet.GetComponent<Rigidbody2D>();
        rb2D.linearVelocity = direction * currentWeapon.bulletSpeed;
    }
}
